using System;
using System.Threading;

//http://www.cnblogs.com/lvcy/archive/2012/06/15/2550061.html

namespace ca_20170426异步执行
{
	class Program
	{
		static void Main(string[] args)
		{
			#region 异步执行
			Func<int, int, int, int> d2 = TakeAWhile;
			IAsyncResult ar = d2.BeginInvoke(1, 3000, 2, null, null);
			while (!ar.IsCompleted)
			{
				Console.Write(".");
				// 等待线程执行完成
				Thread.Sleep(50);
			}
			int result = d2.EndInvoke(ar);
			Console.Write("result:{0}", result);
			#endregion

			Console.ReadKey();
		}

		static int TakeAWhile(int data, int ms, int temp)
		{
			Console.Write("TakesAWhile started");
			Thread.Sleep(ms);
			Console.WriteLine("TakeAWhile Completed");
			return ++data;
		}
	}
}
