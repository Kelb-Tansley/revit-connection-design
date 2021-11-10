using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strand7
{
    public class DetermineUnitFactors
    {
        public static void GetUnitFactors(int[] Units, out double FactorLength, out double FactorForce, out double FactorStress)
        {
            FactorLength = 0;
            FactorForce = 0;
            FactorStress = 0;

            switch (Units[0]) //FactorLength converts the units to mm
            {
                case St7.luMETRE: FactorLength = 1000; break;
                case St7.luCENTIMETRE: FactorLength = 10; break;
                case St7.luMILLIMETRE: FactorLength = 1; break;
                case St7.luFOOT: FactorLength = 304.8; break;
                case St7.luINCH: FactorLength = 25.4; break;
            }
            switch (Units[1])    //FactorForce converts the units to N
            {
                case St7.fuNEWTON: FactorForce = 1; break;
                case St7.fuKILONEWTON: FactorForce = 1000; break;
                case St7.fuMEGANEWTON: FactorForce = 1000000; break;
                case St7.fuKILOFORCE: FactorForce = 9.80665; break;
                case St7.fuTONNEFORCE: FactorForce = 9806.65; break;
                case St7.fuPOUNDFORCE: FactorForce = 4.44822; break;
                case St7.fuKIPFORCE: FactorForce = 4448.22; break;
            }
            switch (Units[2])    //FactorForce converts the units to MPa - To be checked
            {
                case St7.suPASCAL: FactorStress = 0.000001; break;
                case St7.suKILOPASCAL: FactorStress = 0.001; break;
                case St7.suMEGAPASCAL: FactorStress = 1; break;
                case St7.suKSCm: FactorStress = 9.80665; break;
                case St7.suPSI: FactorStress = 9806.65; break;
                case St7.suKSI: FactorStress = 4.44822; break;
                case St7.suPSF: FactorStress = 4448.22; break;
            }
        }
    }
}
