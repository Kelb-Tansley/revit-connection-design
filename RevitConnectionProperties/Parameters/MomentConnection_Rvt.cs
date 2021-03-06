using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitConnectionProperties
{
    public class MomentConnection_Rvt
    {
        public const string AdditionalPlateAtHaunchEnd = "AdditionalPlateAtHaunchEnd";
        public const string AdditionalPlateGap = "AdditionalPlateGap";
        public const string AdditionalPlateHeight2 = "AdditionalPlateHeight2";
        public const string AdditionalPlateLength = "AdditionalPlateLength";
        public const string AdditionalPlateThickness = "AdditionalPlateThickness";
        public const string AdditionalPlateThickness2 = "AdditionalPlateThickness2";
        public const string AdditionalPlateUnderHaunch = "AdditionalPlateUnderHaunch";
        public const string AdditionalPlateWidth = "AdditionalPlateWidth";
        public const string AdditionalPlateWidth2 = "AdditionalPlateWidth2";
        public const string AdditionalRafter = "AdditionalRafter";
        public const string AdditionalRafterClass = "AdditionalRafterClass";
        public const string AdditionalRafterFlange = "AdditionalRafterFlange";
        public const string AdditionalRafterHorizontal = "AdditionalRafterHorizontal";
        public const string AdditionalRafterLength = "AdditionalRafterLength";
        public const string AdditionalRafterLengthDirection = "AdditionalRafterLengthDirection";
        public const string AdditionalRafterSection = "AdditionalRafterSection";
        public const string AdditionalRafterTopDistance = "AdditionalRafterTopDistance";
        public const string AdditionalRafterWeb = "AdditionalRafterWeb";
        public const string BoltInverted = "BoltInverted";
        public const string BoltsAssembly = "BoltsAssembly";
        public const string BoltsDiameter = "BoltsDiameter";
        public const string BoltsDistanceToPreviousBolt = "BoltsDistanceToPreviousBolt";
        public const string BoltsGrade = "BoltsGrade";
        public const string BoltsGroup1Distance = "BoltsGroup1Distance";
        public const string BoltsGroup1LinesDist = "BoltsGroup1LinesDist";
        public const string BoltsGroup1LinesNumber = "BoltsGroup1LinesNumber";
        public const string BoltsGroup1Reinforcement = "BoltsGroup1Reinforcement";
        public const string BoltsGroup2Distance = "BoltsGroup2Distance";
        public const string BoltsGroup2LinesDist = "BoltsGroup2LinesDist";
        public const string BoltsGroup2LinesNumber = "BoltsGroup2LinesNumber";
        public const string BoltsGroup2Reinforcement = "BoltsGroup2Reinforcement";
        public const string BoltsGroup3Distance = "BoltsGroup3Distance";
        public const string BoltsGroup3LinesDist = "BoltsGroup3LinesDist";
        public const string BoltsGroup3LinesNumber = "BoltsGroup3LinesNumber";
        public const string BoltsGroup3Reinforcement = "BoltsGroup3Reinforcement";
        public const string BoltsGroup4Distance = "BoltsGroup4Distance";
        public const string BoltsGroup4LinesDist = "BoltsGroup4LinesDist";
        public const string BoltsGroup4LinesNumber = "BoltsGroup4LinesNumber";
        public const string BoltsGroup4Reinforcement = "BoltsGroup4Reinforcement";
        public const string BoltsHorDistance = "BoltsHorDistance";
        public const string BoltsIntermDistance = "BoltsIntermDistance";
        public const string BoltsNumberPerSide = "BoltsNumberPerSide";
        public const string BoltsOnGaugeLine = "BoltsOnGaugeLine";
        public const string BoltsReinforcementPlateSize = "BoltsReinforcementPlateSize";
        public const string BoltsReinforcementPlateThickness = "BoltsReinforcementPlateThickness";
        public const string BoltsType = "BoltsType";
        public const string CalculatedAxisIntersectionX = "CalculatedAxisIntersectionX";
        public const string CalculatedAxisIntersectionY = "CalculatedAxisIntersectionY";
        public const string CalculatedAxisIntersectionZ = "CalculatedAxisIntersectionZ";
        public const string CalculatedBouExtInfBoltsDist = "CalculatedBouExtInfBoltsDist";
        public const string CalculatedBouExtSupBoltsDist = "CalculatedBouExtSupBoltsDist";
        public const string CalculatedBouInfBoltsDist = "CalculatedBouInfBoltsDist";
        public const string CalculatedEndPlateHeight = "CalculatedEndPlateHeight";
        public const string CalculatedHaunchHeight = "CalculatedHaunchHeight";
        public const string CalculatedHaunchLength = "CalculatedHaunchLength";
        public const string CalculatedRafterAngle = "CalculatedRafterAngle";
        public const string CalculatedRenBoltsFirstDist = "CalculatedRenBoltsFirstDist";
        public const string CalculatedRenBoltsLinesDist = "CalculatedRenBoltsLinesDist";
        public const string CalculatedRenBoltsRows = "CalculatedRenBoltsRows";
        public const string CalculatedTraBoltsFirstDist = "CalculatedTraBoltsFirstDist";
        public const string CalculatedTraBoltsLinesDist = "CalculatedTraBoltsLinesDist";
        public const string CalculatedTraBoltsRows = "CalculatedTraBoltsRows";
        public const string CanBeCalculatedWithMelody = "CanBeCalculatedWithMelody";
        public const string CapPlateGap = "CapPlateGap";
        public const string CapPlateHorizontal = "CapPlateHorizontal";
        public const string CapPlateLength = "CapPlateLength";
        public const string CapPlateThickness = "CapPlateThickness";
        public const string CapPlateType = "CapPlateType";
        public const string CapPlateWidth = "CapPlateWidth";
        public const string Chamfer1 = "Chamfer1";
        public const string Chamfer2 = "Chamfer2";
        public const string Chamfer3 = "Chamfer3";
        public const string ChamferMeasuredVertical = "ChamferMeasuredVertical";
        public const string ColumnChamfer = "ColumnChamfer";
        public const string ColumnChamferHeight = "ColumnChamferHeight";
        public const string ColumnChamferWidth = "ColumnChamferWidth";
        public const string ColumnCornerFinishSizeType = "ColumnCornerFinishSizeType";
        public const string ColumnExtension = "ColumnExtension";
        public const string ColumnStiff1Length = "ColumnStiff1Length";
        public const string ColumnStiff1Sloped = "ColumnStiff1Sloped";
        public const string ColumnStiff1Thickness = "ColumnStiff1Thickness";
        public const string ColumnStiff1Type = "ColumnStiff1Type";
        public const string ColumnStiff2Length = "ColumnStiff2Length";
        public const string ColumnStiff2Sloped = "ColumnStiff2Sloped";
        public const string ColumnStiff2Thickness = "ColumnStiff2Thickness";
        public const string ColumnStiff2Type = "ColumnStiff2Type";
        public const string ColumnStiff3Length = "ColumnStiff3Length";
        public const string ColumnStiff3Sloped = "ColumnStiff3Sloped";
        public const string ColumnStiff3Thickness = "ColumnStiff3Thickness";
        public const string ColumnStiff3Type = "ColumnStiff3Type";
        public const string ColumnStiffeningType = "ColumnStiffeningType";
        public const string ConstructionGap = "ConstructionGap";
        public const string ContinuousColumn = "ContinuousColumn";
        public const string CornerFinOutSideHeight = "CornerFinOutSideHeight";
        public const string CornerFinOutSideWidth = "CornerFinOutSideWidth";
        public const string CornerFinnishType = "CornerFinnishType";
        public const string CreatePlatePreparation = "CreatePlatePreparation";
        public const string CreateRib = "CreateRib";
        public const string EndPlateLength = "EndPlateLength";
        public const string EndPlateLengthChoice = "EndPlateLengthChoice";
        public const string EndPlateProjBottom = "EndPlateProjBottom";
        public const string EndPlateProjLeft = "EndPlateProjLeft";
        public const string EndPlateProjRight = "EndPlateProjRight";
        public const string EndPlateProjTop = "EndPlateProjTop";
        public const string EndPlateThickness = "EndPlateThickness";
        public const string EndPlateWidth = "EndPlateWidth";
        public const string EndPlateWidthChoice = "EndPlateWidthChoice";
        public const string HaunchAsRafter = "HaunchAsRafter";
        public const string HaunchClass = "HaunchClass";
        public const string HaunchEndPlate = "HaunchEndPlate";
        public const string HaunchFlangePlateThickness = "HaunchFlangePlateThickness";
        public const string HaunchFlangePlateWidth = "HaunchFlangePlateWidth";
        public const string HaunchHeight = "HaunchHeight";
        public const string HaunchHeightSettings = "HaunchHeightSettings";
        public const string HaunchLength = "HaunchLength";
        public const string HaunchLengthSettings = "HaunchLengthSettings";
        public const string HaunchPosition = "HaunchPosition";
        public const string HaunchSection = "HaunchSection";
        public const string HaunchType = "HaunchType";
        public const string HaunchWebPlateThickness = "HaunchWebPlateThickness";
        public const string Justification1 = "Justification1";
        public const string Justification2 = "Justification2";
        public const string Justification3 = "Justification3";
        public const string Justification4 = "Justification4";
        public const string MergePlatesPerGroup = "MergePlatesPerGroup";
        public const string MorrisChamfer = "MorrisChamfer";
        public const string MorrisClearance = "MorrisClearance";
        public const string MorrisStartFrom = "MorrisStartFrom";
        public const string MorrisThickness = "MorrisThickness";
        public const string MorrisWidth = "MorrisWidth";
        public const string OffsetBack = "OffsetBack";
        public const string OffsetFromColumn = "OffsetFromColumn";
        public const string OffsetFront = "OffsetFront";
        public const string OutsideStiffCornerFinish1 = "OutsideStiffCornerFinish1";
        public const string OutsideStiffCornerFinish2 = "OutsideStiffCornerFinish2";
        public const string OutsideStiffHeight = "OutsideStiffHeight";
        public const string OutsideStiffLength = "OutsideStiffLength";
        public const string OutsideStiffOnColumn = "OutsideStiffOnColumn";
        public const string OutsideStiffOnRafter = "OutsideStiffOnRafter";
        public const string OutsideStiffThickness = "OutsideStiffThickness";
        public const string OutsideStiffVerticalSideOnColumn = "OutsideStiffVerticalSideOnColumn";
        public const string OutsideStiffVerticalSideOnRafter = "OutsideStiffVerticalSideOnRafter";
        public const string PreparationSize = "PreparationSize";
        public const string RafterChamfer = "RafterChamfer";
        public const string RafterChamferHeight = "RafterChamferHeight";
        public const string RafterChamferWidth = "RafterChamferWidth";
        public const string RafterCornerFinishSizeType = "RafterCornerFinishSizeType";
        public const string RafterCornerFinishType = "RafterCornerFinishType";
        public const string RafterStiff4Length = "RafterStiff4Length";
        public const string RafterStiff4Sloped = "RafterStiff4Sloped";
        public const string RafterStiff4Thickness = "RafterStiff4Thickness";
        public const string RafterStiff4Type = "RafterStiff4Type";
        public const string ReinforcementPlates = "ReinforcementPlates";
        public const string RibChamfer = "RibChamfer";
        public const string RibLength = "RibLength";
        public const string RibNumber = "RibNumber";
        public const string RibShape = "RibShape";
        public const string RibStartFrom = "RibStartFrom";
        public const string RibThickness = "RibThickness";
        public const string RibWidth = "RibWidth";
        public const string S2Chamfer = "S2Chamfer";
        public const string S2ColumnLength = "S2ColumnLength";
        public const string S2CornerFinish = "S2CornerFinish";
        public const string S2CornerFinishSizeAtColumn = "S2CornerFinishSizeAtColumn";
        public const string S2CornerFinishSizeAtRafter = "S2CornerFinishSizeAtRafter";
        public const string S2Height = "S2Height";
        public const string S2Horizontal = "S2Horizontal";
        public const string S2Present = "S2Present";
        public const string S2RafterLength = "S2RafterLength";
        public const string S2Side = "S2Side";
        public const string S2Thickness = "S2Thickness";
        public const string S2TopDistance = "S2TopDistance";
        public const string S2Width = "S2Width";
        public const string SlopedStiffCornerFinishSize = "SlopedStiffCornerFinishSize";
        public const string SlopedStiffCornerFinishSizeType = "SlopedStiffCornerFinishSizeType";
        public const string SlopedStiffCornerFinishType = "SlopedStiffCornerFinishType";
        public const string SlopedStiffDirection = "SlopedStiffDirection";
        public const string SlopedStiffLengthType = "SlopedStiffLengthType";
        public const string SlopedStiffLengthValue = "SlopedStiffLengthValue";
        public const string SlopedStiffThickness = "SlopedStiffThickness";
        public const string SlotDirection = "SlotDirection";
        public const string SlotLength = "SlotLength";
        public const string SlotOffset = "SlotOffset";
        public const string SlottedPart = "SlottedPart";
        public const string Stiffener1Value = "Stiffener1Value";
        public const string Stiffener1Width = "Stiffener1Width";
        public const string Stiffener2Value = "Stiffener2Value";
        public const string Stiffener2Width = "Stiffener2Width";
        public const string Stiffener3Value = "Stiffener3Value";
        public const string Stiffener3Width = "Stiffener3Width";
        public const string Stiffener4Value = "Stiffener4Value";
        public const string Stiffener4Width = "Stiffener4Width";
        public const string Stiffener5Value = "Stiffener5Value";
        public const string Stiffener5Width = "Stiffener5Width";
        public const string Stiffener6Value = "Stiffener6Value";
        public const string Stiffener6Width = "Stiffener6Width";
        public const string UseNewModelRoles = "UseNewModelRoles";
        public const string WebDoublerHeight = "WebDoublerHeight";
        public const string WebDoublerHeightSetting = "WebDoublerHeightSetting";
        public const string WebDoublerSide = "WebDoublerSide";
        public const string WebDoublerThickness = "WebDoublerThickness";
        public const string WebDoublerWidth = "WebDoublerWidth";
        public const string WebDoublerWidthSetting = "WebDoublerWidthSetting";
        public const string WeldAdditionalPlate = "WeldAdditionalPlate";
        public const string WeldCapPlateFlange = "WeldCapPlateFlange";
        public const string WeldCapPlateWeb = "WeldCapPlateWeb";
        public const string WeldHaunchFlange = "WeldHaunchFlange";
        public const string WeldHaunchRafter = "WeldHaunchRafter";
        public const string WeldHaunchWeb = "WeldHaunchWeb";
        public const string WeldPlates = "WeldPlates";
        public const string WeldRafterFlange = "WeldRafterFlange";
        public const string WeldRafterLowerFlange = "WeldRafterLowerFlange";
        public const string WeldRafterWeb = "WeldRafterWeb";
        public const string WeldStiffEndPlate = "WeldStiffEndPlate";
        public const string WeldStiffFlange = "WeldStiffFlange";
        public const string WeldStiffWeb = "WeldStiffWeb";

    }
}
