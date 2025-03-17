using System;
using System.Collections.Concurrent;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.Remoting.Messaging;
using UDP_Server_Middleware;

namespace UDP_server
{
    class DBConnector : Program
    {
        public static SqlConnection _sqlConnection;


        // DB 연결 열기
        public static void MssqlOpen()
        {
            try
            {
                if (_sqlConnection == null)
                {
                    _sqlConnection = new SqlConnection
                    {
                        ConnectionString = string.Format($"Data Source={DataSource}; " +
                                                         $"Initial Catalog={InitialCatalog};" +
                                                         $"Persist Security Info=True;" +
                                                         $"User ID={UserID};" +
                                                         $"Password={Password}")
                    };
                }

                if (_sqlConnection.State != System.Data.ConnectionState.Open)
                {
                    _sqlConnection.Open();
                    //Console.WriteLine("DB 연결 성공");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"MssqlOpen : DB 연결 실패 / {ex.Message}");
            }
        }

        // DB 연결 닫기
        public static void MssqlClose()
        {
            try
            {
                if (_sqlConnection != null && _sqlConnection.State == System.Data.ConnectionState.Open)
                {
                    _sqlConnection.Close();
                    _sqlConnection.Dispose();
                    _sqlConnection = null;
                    //Console.WriteLine("DB 접속 종료 성공");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"MssqlClose : DB 접속 종료 실패 /  {ex.Message}");
            }
        }

       
        #region insert DB

        static public void headerDisplay(string[] dataArr)
        {

            string insertQuery = string.Empty;
            try
            {

                if (dataArr.Length > 0 && dataArr.Length == 8)
                {
                    //insertQuery = 

                }
                // [GID] 포함
                else if (dataArr.Length > 0 && dataArr.Length == 9)
                {
                    //insertQuery = 

                }
                // result가 1이면 insert 성공
                int result = ExecuteNonQuery(insertQuery);
                if (result != 1)
                {
                    Console.WriteLine("display 데이터 insert 실패");
                    insertQuery = "INSERT INTO exception_log (location, msg) VALUES('headerDisplay', 'display 데이터 insert 실패');";
                    ExecuteNonQuery(insertQuery);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("display 데이터 insert 실패");
                insertQuery = "INSERT INTO exception_log (location, msg) VALUES('headerDisplay', 'display 데이터 insert 실패');";
                ExecuteNonQuery(insertQuery);
            }


        }

        static public void headerStatus2(string[] dataArr)
        {
            string insertQuery = string.Empty;
            try
            {
                if (dataArr.Length > 0)
                {
                    //insertQuery = 
                }


                // result가 1이면 insert 성공
                int result = ExecuteNonQuery(insertQuery);
                if (result != 1)
                {
                    Console.WriteLine("status2 데이터 insert 실패");
                    insertQuery = "INSERT INTO exception_log (location, msg) VALUES('headerStatus2', 'status2 데이터 insert 실패');";
                    ExecuteNonQuery(insertQuery);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("status2 데이터 insert 실패");
                insertQuery = "INSERT INTO exception_log (location, msg) VALUES('headerStatus2', 'status2 데이터 insert 실패');";
                ExecuteNonQuery(insertQuery);

            }



        }

        static public void headerStatus3(string[] dataArr)
        {
            string insertQuery = string.Empty;
            try
            {
                if (dataArr.Length > 0)
                {
                    if (dataArr[1].Contains("ANC"))
                    {
                        //insertQuery = 
                    }
                    else if (dataArr[1].Contains("TAG"))
                    {
                        //insertQuery = 
                    }
                }


                // result가 1이면 insert 성공
                int result = ExecuteNonQuery(insertQuery);
                if (result != 1)
                {
                    Console.WriteLine("status3 데이터 insert 실패");
                    insertQuery = "INSERT INTO exception_log (location, msg) VALUES('headerStatus3', 'status3 데이터 insert 실패');";
                    ExecuteNonQuery(insertQuery);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("status3 데이터 insert 실패");
                insertQuery = "INSERT INTO exception_log (location, msg) VALUES('headerStatus3', 'status3 데이터 insert 실패');";
                ExecuteNonQuery(insertQuery);
            }



        }


        #endregion



        // 테이블이 존재하는지 확인하고 없으면 생성
        public static void IsDbExists(string tableName)
        {
            try
            {
                // 테이블 존재 여부 확인 쿼리
                string sqlQuery = $"SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_CATALOG='' AND TABLE_NAME='{tableName}'";
                int result = ExecuteScalarQuery(sqlQuery); // COUNT(*) 결과 가져오기

                if (result == 0) // 테이블이 없으면 생성
                {
                    Console.WriteLine("테이블이 존재하지 않습니다. 테이블을 생성합니다.");
                    string createTableQuery = GetCreateTableQuery(tableName);

                    if (!string.IsNullOrEmpty(createTableQuery))
                    {
                        int resultCreate = ExecuteNonQuery(createTableQuery); // 테이블 생성 및 더미 데이터 삽입
                        if (resultCreate > 0)
                        {
                            Console.WriteLine($"테이블 생성 성공 : {tableName}");
                        }
                        else
                        {
                            Console.WriteLine($"테이블 생성에 실패하였습니다. : {tableName}");
                        }
                    }
                }
                else
                {
                    Console.WriteLine($"테이블이 이미 존재합니다: {tableName}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"오류 발생: {ex.Message}");
            }
        }

        public static string ExecuteReaderQuery(string query)
        {
            string result = string.Empty;

            try
            {
                if (_sqlConnection == null || _sqlConnection.State != System.Data.ConnectionState.Open)
                {
                    MssqlOpen();
                }

                using (SqlCommand command = new SqlCommand(query, _sqlConnection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        if (reader != null)
                        {
                            //result = 
                        }
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ExecuteReaderQuery 오류: {ex.Message}");
            }

            return result;
        }

        // 쿼리 실행 후 단일 값 반환
        public static int ExecuteScalarQuery(string query)
        {
            int result = 0;
            try
            {
                if (_sqlConnection == null || _sqlConnection.State != System.Data.ConnectionState.Open)
                {
                    MssqlOpen();
                }

                using (SqlCommand command = new SqlCommand(query, _sqlConnection))
                {
                    object scalarResult = command.ExecuteScalar();
                    if (scalarResult != null)
                    {
                        result = Convert.ToInt32(scalarResult);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ExecuteScalarQuery 오류: {ex.Message}");
            }
            return result;
        }

        // 쿼리 실행 (CREATE/INSERT 등)
        public static int ExecuteNonQuery(string query)
        {
            int result = 0;
            try
            {
                if (_sqlConnection == null || _sqlConnection.State != System.Data.ConnectionState.Open)
                {
                    MssqlOpen();
                }

                using (SqlCommand command = new SqlCommand(query, _sqlConnection))
                {
                    result = command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ExecuteNonQuery 오류: {ex.Message}");
            }
            return result;
        }

        // 테이블 생성 쿼리 반환
        private static string GetCreateTableQuery(string tableName)
        {


            switch (tableName)
            {
                //
                default:
                    return null;
            }


        }




    }

}


