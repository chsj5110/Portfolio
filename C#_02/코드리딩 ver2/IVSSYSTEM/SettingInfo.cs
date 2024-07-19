using System;
using System.Runtime.InteropServices;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace IVSSYSTEM
{
    class SettingInfo
    {
        /// <summary>
        /// INI 파일에 섹션과 키로 검색하여 값을 저장합니다.
        /// </summary>
        /// <param name="lpAppname">섹션명입니다.</param>
        /// <param name="lpKeyName">키값명입니다.</param>
        /// <param name="lpString">저장 할 문자열입니다.</param>
        /// <param name="lpFileName">파일 이름입니다.</param>
        /// <returns>처리 여부입니다.</returns>
        [DllImport("kernel32.dll")]
        public static extern bool WritePrivateProfileString(string lpAppName, string lpKeyName, string lpString, string lpFileName);

        /// <summary>
        /// INI 파일에 섹션과 키로 검색하여 값을 문자열형으로 읽어 옵니다.
        /// </summary>
        /// <param name="lpAppname">섹션명입니다.</param>
        /// <param name="lpKeyName">키값명입니다.</param>
        /// <param name="lpDefault">기본 문자열입니다.</param>
        /// <param name="lpReturnedString">가져온 문자열입니다.</param>
        /// <param name="nSize">문자열 버퍼의 크기입니다.</param>
        /// <param name="lpFileName">파일 이름입니다.</param>
        /// <returns>가져온 문자열 크기입니다.</returns>
        [DllImport("kernel32.dll")]
        public static extern uint GetPrivateProfileString(string lpAppName, string lpKeyName, string lpDefault, StringBuilder lpReturnedString, uint nSize, string lpFileName);

        public String SettingReadValue(String Section, String Key, String IniPath)
        {
            StringBuilder temp = new StringBuilder(255);
            uint i = GetPrivateProfileString(Section, Key, "", temp, 1024, IniPath);
            return temp.ToString();
        }

        public void SettingWriteValue(String Section, String Key, String Value, String IniPath)
        {
            WritePrivateProfileString(Section, Key, Value, IniPath);
        }

    }
}
