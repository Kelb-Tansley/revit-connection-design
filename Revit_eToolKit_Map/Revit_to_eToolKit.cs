using eToolKit_Classes;
using Models_SC_Proj;
using RevitConnectionProperties;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revit_eToolKit_Map
{
    public class Revit_to_eToolKit : IRevit_eToolKit_Mapping
    {
        public static MomentConnection Map_Revit_to_eToolKit_MomentConnection(ObservableCollection<Parameter_Items> OriginalParameterList)
        {
            #region Initialize Local Variables
            string Bolts_Diameter = "M20";
            string Bolts_Grade = "8.8";
            int Bolts_Number_Lines = 0;
            int Bolts_Number_Rows_AboveBF = 0;
            int Bolts_Number_Rows_AboveTF = 0;
            int Bolts_Number_Rows_BelowBF = 0;
            int Bolts_Number_Rows_BelowTF = 0;
            string ColumnSection = "";
            bool ColumnStiffeners_Bottom = false;
            bool ColumnStiffeners_Top = false;
            bool ColumnStiffeners_Web = false;
            double ConnectedtoThickness = 0;
            double HaunchDepth = 0;
            double Plate_EndorFin_Height = 0;
            double Plate_EndorFin_Thickness = 0;
            double Plate_EndorFin_Weld = 0;
            double Plate_EndorFin_Width = 0;
            string Section_Angle = "";
            string Section_Supported = "";
            string SteelGrade = "355JR";
            double ULS_Fu = 0;
            double ULS_Mu = 0;
            double ULS_Vu = 0;
            #endregion

            foreach (Parameter_Items item in OriginalParameterList)
            {
                if (item.Description==MomentConnection_Rvt.BoltsDiameter) //Bolts_Diameter
                {
                    Bolts_Diameter = item.Value;
                    continue;
                }
                else if (item.Description == MomentConnection_Rvt.BoltsGrade) //Bolts_Grade
                {
                    Bolts_Grade = item.Value;
                    continue;
                }
                else if (item.Description == MomentConnection_Rvt.BoltsGroup1LinesNumber) //Bolts_Number_Lines
                {
                    Int32.TryParse(item.Value, out Bolts_Number_Lines);
                    continue;
                }
                else if (item.Description == MomentConnection_Rvt.BoltsGroup1LinesNumber) //Bolts_Number_Rows_AboveBF
                {
                    Int32.TryParse(item.Value, out Bolts_Number_Rows_AboveBF);
                    continue;
                }
                else if (item.Description == MomentConnection_Rvt.BoltsGroup2LinesNumber) //Bolts_Number_Rows_AboveTF
                {
                    Int32.TryParse(item.Value, out Bolts_Number_Rows_AboveTF);
                    continue;
                }
                else if (item.Description == MomentConnection_Rvt.BoltsGroup3LinesNumber) //Bolts_Number_Rows_BelowBF
                {
                    Int32.TryParse(item.Value, out Bolts_Number_Rows_BelowBF);
                    continue;
                }
                else if (item.Description == MomentConnection_Rvt.BoltsGroup4LinesNumber) //Bolts_Number_Rows_BelowTF
                {
                    Int32.TryParse(item.Value, out Bolts_Number_Rows_BelowTF);
                    continue;
                }
                //else if (item.Description == MomentConnection_Rvt.c) //ColumnSection
                //{
                //    
                //    continue;
                //}
                else if (item.Description == MomentConnection_Rvt.ColumnStiff1Type) //ColumnStiffeners_Bottom
                {
                    //Boolean.TryParse(item.Value, out ColumnStiffeners_Bottom);
                    continue;
                }
                else if (item.Description == MomentConnection_Rvt.ColumnStiff2Type) //ColumnStiffeners_Top
                {
                    //Boolean.TryParse(item.Value, out ColumnStiffeners_Top);
                    continue; 
                }
                else if (item.Description == MomentConnection_Rvt.ColumnStiff3Type) //ColumnStiffeners_Web
                {
                    //Boolean.TryParse(item.Value, out ColumnStiffeners_Web);
                    continue;
                }
                else if (item.Description == MomentConnection_Rvt.BoltsDiameter) //ConnectedtoThickness
                {
                    Double.TryParse(item.Value, out ConnectedtoThickness);
                    continue;
                }
                else if (item.Description == MomentConnection_Rvt.HaunchHeight) //HaunchDepth
                {
                    Double.TryParse(item.Value, out HaunchDepth);
                    continue;
                }
                else if (item.Description == MomentConnection_Rvt.HaunchHeight) //Plate_EndorFin_Height
                {
                    Double.TryParse(item.Value, out Plate_EndorFin_Height);
                    continue;
                }
                else if (item.Description == MomentConnection_Rvt.HaunchFlangePlateThickness) //Plate_EndorFin_Thickness
                {
                    Double.TryParse(item.Value, out Plate_EndorFin_Thickness);
                    continue;
                }
                else if (item.Description == MomentConnection_Rvt.WeldHaunchFlange) //Plate_EndorFin_Weld
                {
                    Double.TryParse(item.Value, out Plate_EndorFin_Weld);
                    continue;
                }
                else if (item.Description == MomentConnection_Rvt.HaunchFlangePlateWidth) //Plate_EndorFin_Width
                {
                    Double.TryParse(item.Value, out Plate_EndorFin_Width);
                    continue;
                }
                else if (item.Description == MomentConnection_Rvt.BoltsDiameter) //Section_Angle
                {
                    Section_Angle = item.Value;
                    continue;
                }
                else if (item.Description == MomentConnection_Rvt.BoltsDiameter) //Section_Supported
                {
                    Section_Supported = item.Value;
                    continue;
                }
                else if (item.Description == MomentConnection_Rvt.BoltsDiameter) //SteelGrade
                {
                    SteelGrade = item.Value;
                    continue;
                }
                else if (item.Description == MomentConnection_Rvt.BoltsDiameter) //ULS_Fu
                {
                    Double.TryParse(item.Value, out ULS_Fu);
                    continue;
                }
                else if (item.Description == MomentConnection_Rvt.BoltsDiameter) //ULS_Mu
                {
                    Double.TryParse(item.Value, out ULS_Mu);
                    continue;
                }
                else if (item.Description == MomentConnection_Rvt.BoltsDiameter) //ULS_Vu
                {
                    Double.TryParse(item.Value, out ULS_Vu);
                    continue;
                }
                else if (item.Description == MomentConnection_Rvt.EndPlateThickness) //ULS_Fu
                {
                    Double.TryParse(item.Value, out Plate_EndorFin_Thickness);
                    continue;
                }
                else if (item.Description == MomentConnection_Rvt.EndPlateWidth) //ULS_Mu
                {
                    Double.TryParse(item.Value, out Plate_EndorFin_Width);
                    continue;
                }
                else if (item.Description == MomentConnection_Rvt.EndPlateLength) //ULS_Vu
                {
                    Double.TryParse(item.Value, out Plate_EndorFin_Height);
                    continue;
                }
            }

            #region Populate ouput MomentConnection_eT
            MomentConnection LocalMomentConnection = new MomentConnection();

            LocalMomentConnection.Bolts_Diameter = Bolts_Diameter;
            LocalMomentConnection.Bolts_Grade = Bolts_Grade;
            LocalMomentConnection.Bolts_Number_Lines = Bolts_Number_Lines;
            LocalMomentConnection.Bolts_Number_Rows_AboveBF = Bolts_Number_Rows_AboveBF;
            LocalMomentConnection.Bolts_Number_Rows_AboveTF = Bolts_Number_Rows_AboveTF;
            LocalMomentConnection.Bolts_Number_Rows_BelowBF = Bolts_Number_Rows_BelowBF;
            LocalMomentConnection.Bolts_Number_Rows_BelowTF = Bolts_Number_Rows_BelowTF;
            LocalMomentConnection.ColumnSection = ColumnSection;
            LocalMomentConnection.ColumnStiffeners_Bottom = ColumnStiffeners_Bottom;
            LocalMomentConnection.ColumnStiffeners_Top = ColumnStiffeners_Top;
            LocalMomentConnection.ColumnStiffeners_Web = ColumnStiffeners_Web;
            LocalMomentConnection.ConnectedtoThickness = ConnectedtoThickness;
            LocalMomentConnection.HaunchDepth = HaunchDepth;
            LocalMomentConnection.Plate_EndorFin_Height = Plate_EndorFin_Height;
            LocalMomentConnection.Plate_EndorFin_Thickness = Plate_EndorFin_Thickness;
            LocalMomentConnection.Plate_EndorFin_Weld = Plate_EndorFin_Weld;
            LocalMomentConnection.Plate_EndorFin_Width = Plate_EndorFin_Width;
            LocalMomentConnection.Section_Angle = Section_Angle;
            LocalMomentConnection.Section_Supported = Section_Supported;
            LocalMomentConnection.SteelGrade = SteelGrade;

            LocalMomentConnection.ULS_Fu = ULS_Fu;
            LocalMomentConnection.ULS_Mu = ULS_Mu;
            LocalMomentConnection.ULS_Vu = ULS_Vu;
            #endregion

            return LocalMomentConnection;
        }
    }
}
