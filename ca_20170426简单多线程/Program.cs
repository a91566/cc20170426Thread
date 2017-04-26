using System;
using System.Threading;

namespace ca_20170426简单多线程
{
	class Program
	{
		static void Main(string[] args)
		{
			int count = 50;
			Thread[] tarray = new Thread[count];
			for (int i = 0; i < count; i++)
			{
				tarray[i] = new Thread(new ThreadStart(() => dowork(i)));
				tarray[i].Start();
			}

			#region 等待每个线程都结束了 如果没有这一段 "All is Done" 会被提前输出
			for (int i = 0; i < count; i++)
			{
				tarray[i].Join();
			}
			#endregion
			Console.WriteLine("All is Done");

			Console.ReadKey();
			
		}

		static void dowork(int x)
		{
			System.Threading.Thread.Sleep(500);
			Console.WriteLine($"{ x }:{ System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}");
		}
	}
}
