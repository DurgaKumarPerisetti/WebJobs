using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace WebJobsSDKSample
{
    public class Functions
    {
        public static void ProcessQueueMessage([QueueTrigger("testq")] string message, ILogger logger)
        {
            logger.LogInformation(message);
        }

        public void MyTimerTriggerOperation([TimerTrigger("0 */5 * * * *", RunOnStartup = true)] TimerInfo timerInfo)
        {
            Console.WriteLine("Web job is completed now..!    " + DateTime.Now);
            if (timerInfo.IsPastDue == true)
            {
                Console.WriteLine("The job is Delayed");
            } else {
                Console.WriteLine("The job is completed on time");
            }
        }
     }
}