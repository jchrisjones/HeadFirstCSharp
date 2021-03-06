﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter_06_4_BeehiveManagement_BeanCounters
{
    class Queen : Bee
    {
        //========= Fields ===========//

        private Worker[] _workers;
        private int _shiftNumber = 0;

        //========= Constructors ========//

        public Queen(double weightMg, Worker[] workers) : base(weightMg)
        {

            _workers = workers;
        }

        //========= Methods ==========//

        public bool AssignWork(string job, int numberOfShifts)
        {
            foreach(Worker bee in _workers)
            {
                if (bee.DoThisJob(job, numberOfShifts))
                    return true;                
            }
            return false;
        }

        public string WorkTheNextShift()
        {
            double honeyConsumed = HoneyConsumptionRate();

            _shiftNumber++;
            string report = "Report for shift #" + _shiftNumber + "\r\n";
            for(int i = 0; i < _workers.Length; i++)
            {
                honeyConsumed += _workers[i].HoneyConsumptionRate();

                if(_workers[i].DidYouFinish())
                    report += "Worker #" + (i + 1) + " finished the job.\r\n";
                if (String.IsNullOrEmpty(_workers[i].CurrentJob))
                    report += "Worker #" + (i + 1) + " is not working.\r\n";
                else
                {
                    if (_workers[i].ShiftsLeft > 0)
                        report += "Worker #" + (i + 1) + " is doing \"" + _workers[i].CurrentJob
                            + "\" for " + _workers[i].ShiftsLeft + " more shifts.\r\n";
                    else
                        report += "Worker #" + (i + 1) + " will be done with \"" +
                            _workers[i].CurrentJob + "\" after this shift\r\n";
                }
            }

            report += "Total honey consumed for the shift: " + honeyConsumed + " units.\r\n";

            return report;
        }
    }
}
