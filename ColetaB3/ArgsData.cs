using System;
using System.Collections.Generic;
using System.Text;

namespace ColetaB3
{
    public class ArgsData 
    {
        public string shareString { get; set; }

        public double UpperLimit { get; set; }
        public double InferiorLimit { get; set; }
        
        private bool _isValid = false; 
        public ArgsData(string [] arry)
        {
            this._isValid = GetArgs(arry);
        }

        public bool IsValid() => this._isValid;

        bool GetArgs(string[] args)
        {
            try
            {
                shareString = args[0];
                UpperLimit = double.Parse(args[1]);
                InferiorLimit = double.Parse(args[2]);

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(string.Format("Method: {0}, Message: {1} OptMessage: Passgem de parametros invalida",
                    System.Reflection.MethodBase.GetCurrentMethod().Name, e.Message));
                return false;
            }

        }
    }
}
