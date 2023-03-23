using System;
using System.Collections.Generic;
using System.Text;
using CRC;

namespace CRC16
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Crc16Ccitt crc16Ccitt = new Crc16Ccitt();
            
            Console.Write("원하는 내용을 입력하세요. ");
            string a = Console.ReadLine();
            
            var r = crc16Ccitt.ComputeChecksum(Encoding.UTF8.GetBytes(a));
            Console.WriteLine(r);

            var stringByte = Encoding.UTF8.GetBytes(a);
            var crcByte = BitConverter.GetBytes(r);
            
            
            // 검증할 데이터
            List<byte> data = new List<byte>();

            foreach (var d1 in stringByte)
            {
                data.Add(d1);
            }

            foreach (var d2 in crcByte)
            {
                data.Add(d2);
            }
            // CRC-16 계산 결과를 저장할 변수
            ushort crcResult;

            // 데이터와 함께 계산한 CRC-16 값을 비교하여 검증
            if (crc16Ccitt.VerifyChecksum(data.ToArray()))
            {
                // 검증 성공
                Console.WriteLine("CRC 검증 성공");
            }
            else
            {
                // 검증 실패
                Console.WriteLine("CRC 검증 실패");
            }
        }
    }
}