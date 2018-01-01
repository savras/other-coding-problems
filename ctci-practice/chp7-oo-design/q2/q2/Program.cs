// Ref:
// https://codereview.stackexchange.com/questions/43087/modelling-a-call-center
// https://tianrunhe.wordpress.com/2012/03/18/design-the-classes-and-data-structures-for-a-call-center/
// Definition: Can't handle call = not available or manually triggered by the employee.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace q2
{
    class Program
    {
        static void Main(string[] args)
        {
            var callCenter = new CallCenter();
            callCenter.DispatchCall();
        }
    }

    public enum CallRank
    {
        Respondent,
        Manager,
        Director
    }

    public class Call
    {
        public int Id { get; set; }
        public CallRank Rank { get; set; }
    }

    public class CallCenter
    {
        private readonly Director _director;
        private readonly Manager _manager;
        private readonly List<Respondent> _respondents;
        private readonly List<Call> _calls;

        public CallCenter()
        {
            _director = new Director
            {
                EmployeeId = 1,
                Rank = CallRank.Director
            };
            _manager = new Manager
            {
                EmployeeId = 2,
                Rank = CallRank.Manager
            };
            _respondents = new List<Respondent>
            {
                new Respondent
                {
                    EmployeeId = 3,
                    Rank = CallRank.Respondent
                },
                new Respondent
                {
                    EmployeeId = 4,
                    Rank = CallRank.Respondent
                }
            };
            _calls = new List<Call>
            {
                new Call
                {
                    Rank = CallRank.Respondent
                }
            };

        }

        public void AddCall(Call call)
        {
            _calls.Add(call);
        }

        public void DispatchCall()
        {
            var call = _calls.FirstOrDefault();
            if (call != null)
            {
                Employee employee = _respondents.FirstOrDefault(e => e.CanAnswerCall);
                if (employee == null)
                {

                    if (_manager.CanAnswerCall)
                    {
                        employee = _manager;
                    }

                    if (_director.CanAnswerCall)
                    {
                        employee = _director;
                    }
                }

                if (employee != null)
                {
                    employee.CanAnswerCall = false;
                    if (employee.TakeCall(call))
                    {
                        employee.CanAnswerCall = true;
                        _calls.Remove(call);
                    }
                }
            }
        }
    }

    public interface ICanEscalate
    {
        void Escalate(Call call);
    }

    public interface IEmployee
    {
        bool TakeCall(Call call);
    }

    public class Employee : IEmployee
    {
        public int EmployeeId { get; set; }
        public bool CanAnswerCall { get; set; }
        public CallRank Rank { get; set; }

        public virtual bool TakeCall(Call call)
        {
            return false;
        }
    }

    public class Respondent : Employee, ICanEscalate
    {
        public void Escalate(Call call)
        {
            call.Rank = CallRank.Manager;
        }

        public override bool TakeCall(Call call)
        {
            // Take respondent level call

            var rand = new Random();
            var canResolveChance = rand.Next(0, 10);

            if (canResolveChance >= 0 && canResolveChance <= 7)
            {
                return true;
            }

            Escalate(call);
            return false;
        }
    }

    public class Manager : Employee, ICanEscalate
    {
        public void Escalate(Call call)
        {
            call.Rank = CallRank.Director;
        }

        public override bool TakeCall(Call call)
        {
            // Take manager level call
            var rand = new Random();
            var isEscalate = rand.Next(0, 10);

            if (isEscalate >= 8 && isEscalate <= 9)
            {
                return true;
            }

            Escalate(call);
            return false;
        }
    }

    public class Director : Employee
    {
        public override bool TakeCall(Call call)
        {
            // Take director level call
            // The director can close any calls if answered
            return true;
        }
    }
}
