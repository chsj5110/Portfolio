using System;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using UDP_server;

namespace UDP_Server_Middleware
{
    class Program
    {
        static string receivedMessage = string.Empty;
        static string receivedMessageFromRTLS = string.Empty;
        public static int Port = 0;
        public static string DataSource = string.Empty;
        public static string InitialCatalog = string.Empty;
        public static string UserID = string.Empty;
        public static string Password = string.Empty;
        static void Main(string[] args)
        {

            // port 번호 받기
            GetPort();
            // DB 정보 받기
            GetDBInfo();

            try//예외 처리
            {

                checkDBTables();

                //int port = 53000; // 서버에서 사용할 포트 번호
                UdpClient udpServer = new UdpClient(Port);

                Console.WriteLine($"{Port} 포트에서 대기 중...");

                while (true)
                {
                    DataSet dataSet = new DataSet();

                    // 클라이언트로부터 데이터 수신 및 연결 확인
                    if (IsClientConnected(udpServer, TimeSpan.FromSeconds(5)))
                    {
                        // 헤더구분
                        (string header, string data) = splitHeader(receivedMessage);
                        string[] dataArr = data.Split(',');
                        switch (header)
                        {
                            case "display":
                                DBConnector.headerDisplay(dataArr);
                                
                                udpClient(data, header);    // 데이터 다시 송신
                                break;
                            case "status2":
                                DBConnector.headerStatus2(dataArr);
                                break;
                            case "status3":
                                DBConnector.headerStatus3(dataArr);
                                break;
                            default:
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine($"{DateTime.Now} : 클라이언트와 연결이 끊어졌습니다. 다시 연결 시도 중...");
                        continue; // 다시 대기
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("실패");
                Console.WriteLine(ex.ToString());
            }

        }

        // 포트번호 입력받기
        static void GetPort()
        {
            while (Port == 0)
            {
                Console.WriteLine("UDP 서버에서 사용할 포트 번호를 입력하세요 : ");
                Int32.TryParse(Console.ReadLine(), out Port);

                // 입력하지 않았거나 숫자 입력이 아닐때
                if (Port == 0)
                {
                    Console.WriteLine("잘못된 입력입니다. 다시 입력해주세요.");
                }
            }
        }
        static void GetDBInfo()
        {
            // DB 정보 입력받기
            Console.WriteLine("DB 서버 IP를 입력하세요 : ");
            DataSource = Console.ReadLine();
            Console.WriteLine("연결할 DB 이름을 입력하세요 : ");
            InitialCatalog = Console.ReadLine();
            Console.WriteLine("DB 서버 계정 ID를 입력하세요 : ");
            UserID = Console.ReadLine();
            Console.WriteLine("DB 서버 계정 비밀번호를 입력하세요 : ");
            Password = Console.ReadLine();
        }

        // udpServer : RTLS로부터 DB 요청 받을때
        static public void udpServerForRTLS(UdpClient udpServer)
        {
            while (true)
            {
                try
                {
                    // 클라이언트로부터 데이터 수신
                    IPEndPoint clientEndpoint = new IPEndPoint(IPAddress.Any, 0);
                    byte[] receivedBytes = udpServer.Receive(ref clientEndpoint);
                    string receivedMessage = Encoding.UTF8.GetString(receivedBytes);

                    // 클라이언트 정보 출력
                    Console.WriteLine($"[{clientEndpoint.Address}:{clientEndpoint.Port}]로부터 메시지 수신: {receivedMessage}");

                    // 클라이언트에 응답 전송 (옵션)
                    string responseMessage = "메시지 수신 확인!";
                    byte[] responseBytes = Encoding.UTF8.GetBytes(responseMessage);
                    udpServer.Send(responseBytes, responseBytes.Length, clientEndpoint);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"오류 발생: {ex.Message}");
                }
            }
        }

        // udpClient
        static public void udpClient(string data, string header)
        {
            UdpClient udpClient = new UdpClient();
            string serverIP = "127.0.0.1"; // 서버 주소
            int serverPort = 12345;        // 서버 포트

            string message = header + ',' + data;

            //Console.WriteLine($"RTLS 프로그램으로 send : {message}");

            // 데이터 전송
            byte[] sendData = Encoding.UTF8.GetBytes(message);

            try
            {
                udpClient.Send(sendData, sendData.Length, serverIP, serverPort);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        // 테이블 유무 확인 및 생성하고 테스트 데이터 삽입
        static void checkDBTables()
        {
            DBConnector.IsDbExists("display");
            DBConnector.IsDbExists("status2");
            DBConnector.IsDbExists("status3");

            DBConnector.IsDbExists("exception_log");
        }

        // 클라이언트 메시지 수신이 계속 되고 있는지 확인
        static bool IsClientConnected(UdpClient udpServer, TimeSpan timeout)
        {
            try
            {
                IPEndPoint clientEndpoint = new IPEndPoint(IPAddress.Any, 0);
                // 타임아웃 설정
                Task<byte[]> receiveTask = Task.Run(() =>
                {
                    return udpServer.Receive(ref clientEndpoint);
                });

                if (receiveTask.Wait(timeout))
                {
                    byte[] receivedBytes = receiveTask.Result;
                    receivedMessage = Encoding.UTF8.GetString(receivedBytes);
                    Console.WriteLine($"{clientEndpoint.Address} 클라이언트로부터 메시지 수신: {receivedMessage}");
                    // RTLS
                    if (receivedMessage == "RTLS : DB Info Request")
                    {
                        // 클라이언트에 응답 전송 (옵션)
                        string responseMessage = $"DBInfo,{DataSource},{InitialCatalog},{UserID},{Password}";
                        byte[] responseBytes = Encoding.UTF8.GetBytes(responseMessage);
                        udpServer.Send(responseBytes, responseBytes.Length, clientEndpoint);
                        Console.WriteLine($"{clientEndpoint.Address} 클라이언트로 응답 전송: {responseMessage}");
                    }


                    return true; // 데이터 수신 성공
                }
                else
                {
                    return false; // 타임아웃 발생
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"오류 발생: {ex.Message}");
                return false;
            }
        }


        // 수신한 메시지 헤더 구분하기
        // header와 나머지 패킷
        static public (string, string) splitHeader(string data)
        {
            if (string.IsNullOrEmpty(data))
            {
                throw new ArgumentException("입력 문자열이 비어있거나 null입니다.");
            }

            string[] parts = data.Split(':');
            if (parts.Length < 2)
            {
                throw new ArgumentException("입력 문자열에 두 번째 항목이 존재하지 않습니다.");
            }

            int startIndex = 2; 
            string result = string.Join(":", parts.Skip(startIndex));

            return (parts[1], result.Trim());
        }

    }
}


