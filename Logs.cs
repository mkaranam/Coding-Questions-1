using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCup.Google
{
    class Logs
    {
        public List<LogEntry> logs;
        public void createLogs()
        {
            logs = new List<LogEntry>();
            logs.Add(new LogEntry(1, 2, 1, 4));
            logs.Add(new LogEntry(2, 3, 2, 7));
            logs.Add(new LogEntry(3, 10, 2, 5));
            logs.Add(new LogEntry(4, 9, 3, 8));
            logs.Add(new LogEntry(5, 2, 1, 6));
            logs.Add(new LogEntry(6, 2, 4, 5));
            logs.Add(new LogEntry(7, 4, 3, 4));
            logs.Add(new LogEntry(8, 6, 3, 8));
        }

        public void printlogs()
        {
            Console.WriteLine("List of logs: ");
            foreach (LogEntry log in logs)
            {
                Console.WriteLine("Job ID: {0}, Start time: {1}, End time: {2}, Ram: {3}",log.jobId,log.startTime,log.endTime,log.ram);
            }
            Console.WriteLine("\n");
        }

        public int peakRAM()
        {
            Dictionary<int, int> timeStamp = new Dictionary<int, int>();
            int max = 0;
            foreach (LogEntry log in logs)
            {
                if (!timeStamp.ContainsKey(log.startTime)) timeStamp.Add(log.startTime, log.ram);
                else
                {
                    timeStamp[log.startTime] += log.ram;
                }

                for (int i = 0; i < timeStamp.Count;i++ )
                {
                    var item = timeStamp.ElementAt(i);
                    if (item.Key > log.startTime && item.Key < log.endTime)
                    {
                        int temp = log.ram + timeStamp[item.Key];
                        if (max < temp) max = temp;
                        timeStamp[item.Key] = temp;
                    }
                }
                if (!timeStamp.ContainsKey(log.endTime)) timeStamp.Add(log.endTime, 0);
            }
            return max;
        }

        public class LogEntry
        {
            public readonly int startTime;
            public readonly int endTime;
            public readonly int ram;
            public readonly int jobId;

            public LogEntry(int Id,int ram, int sT, int eT)
            {
                jobId = Id;
                this.ram = ram;
                startTime = sT;
                endTime = eT;
            }
            
        }
    }
}
