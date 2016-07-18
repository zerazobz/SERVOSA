using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using Xdr = DocumentFormat.OpenXml.Drawing.Spreadsheet;
using SERVOSA.SAIR.DATAACCESS.Contracts;
using SERVOSA.SAIR.DATAACCESS.Models.Driver;
using SERVOSA.SAIR.SERVICE.Contracts;
using SERVOSA.SAIR.SERVICE.Models;
using SERVOSA.SAIR.SERVICE.Models.Driver;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Data;
using System;

namespace SERVOSA.SAIR.SERVICE.Realizations
{
    public class DriverService : IDriverService
    {
        private readonly IDriverRepository _vehicleRepository;

        public DriverService(IDriverRepository injectedVehicleRepo)
        {
            _vehicleRepository = injectedVehicleRepo;
        }

        public int Create(DriverServiceModel viewModel)
        {
            DriverModel model = null;
            DriverServiceModel.ToModel(viewModel, ref model);
            return _vehicleRepository.Create(model);
        }

        public int Delete(DriverServiceModel viewModel)
        {
            DriverModel model = null;
            DriverServiceModel.ToModel(viewModel, ref model);
            return _vehicleRepository.Delete(model);
        }

        public IList<DriverServiceModel> GetAll()
        {
            DriverServiceModel viewModel = null;
            return _vehicleRepository.GetAll().Select(v =>
            {
                DriverServiceModel.ToViewModel(v, ref viewModel);
                return viewModel;
            }).ToList();
        }

        public IList<DriverServiceModel> GetAllFiltered(int minRow, int maxRow)
        {
            DriverServiceModel vehicleViewModel = null;
            return _vehicleRepository.GetAllFiltered(minRow, maxRow).Select(v =>
            {
                DriverServiceModel.ToViewModel(v, ref vehicleViewModel);
                return vehicleViewModel;
            }).ToList();
        }

        public IList<DriverServiceModel> GetAllFilteredBySearchTerm(string searchTerm)
        {
            DriverServiceModel vehicleViewModel = null;
            return _vehicleRepository.GetAllFilteredBySearchTerm(searchTerm).Select(v =>
            {
                DriverServiceModel.ToViewModel(v, ref vehicleViewModel);
                return vehicleViewModel;
            }).ToList();
        }

        public DriverServiceModel GetById(int id)
        {
            DriverServiceModel vehicleServiceModel = null;
            var vehicleResult = _vehicleRepository.GetById(id);
            DriverServiceModel.ToViewModel(vehicleResult, ref vehicleServiceModel);
            return vehicleServiceModel;
        }

        public int Update(DriverServiceModel viewModel)
        {
            DriverModel model = null;
            DriverServiceModel.ToModel(viewModel, ref model);
            return _vehicleRepository.Update(model);
        }

        public IList<DriverHeadRowServiceModel> GetDriverRowDataForTable(string tableName)
        {
            DriverHeadRowServiceModel modelResult = null;
            var vehicleData = _vehicleRepository.GetRowDataForTable(tableName).Select(vD =>
            {
                DriverHeadRowServiceModel.ToServiceModel(vD, ref modelResult);
                return modelResult;
            }).ToList();

            return vehicleData;
        }

        public DriverVariableDataServiceModel GetDriverVariableTableData(string tableName, int vehicleCode)
        {
            DriverVariableDataServiceModel serviceModel = null;
            var dataResult = _vehicleRepository.GetDriverVariableTableData(tableName, vehicleCode);
            DriverVariableDataServiceModel.ToServiceModel(dataResult, ref serviceModel);
            serviceModel.IsSuccessful = true;
            return serviceModel;
        }

        public IList<DriverRelatedTableServiceModel> GetRelatedTablesToDriver()
        {
            DriverRelatedTableServiceModel vehicleRelatedVM = null;
            var relatedVehiclesCollection = _vehicleRepository.GetRelatedTablesToDriver().Select(rVT =>
            {
                DriverRelatedTableServiceModel.ToServiceModel(rVT, ref vehicleRelatedVM);
                return vehicleRelatedVM;
            }).ToList();
            return relatedVehiclesCollection;
        }

        public IList<string> GetListRelatedTablesToDriver()
        {
            return GetRelatedTablesToDriver().Select(rV => rV.ForeignTable).ToList();
        }

        public void GenerateReportForTable(string tableName, Stream streamData)
        {
            using (SpreadsheetDocument package = SpreadsheetDocument.Create(streamData, SpreadsheetDocumentType.Workbook))
            {
                var dataResultToExport = _vehicleRepository.GetVariableDataToExport(tableName);
                CreateWorkBookFromDataSet(package, dataResultToExport, tableName);
            }
        }

        public void GenerateReportForDriver(int vehicleCode, Stream streamData)
        {
            using (SpreadsheetDocument package = SpreadsheetDocument.Create(streamData, SpreadsheetDocumentType.Workbook))
            {
                var dataResultToExport = _vehicleRepository.GetDriverDataToExport(vehicleCode);
                CreateWorkBookFromDataSet(package, dataResultToExport);
            }
        }

        private void CreateWorkBookFromDataSet(SpreadsheetDocument workbook, DataSet ds, string tableName = null)
        {
            var workbookPart = workbook.AddWorkbookPart();

            workbook.WorkbookPart.Workbook = new DocumentFormat.OpenXml.Spreadsheet.Workbook();

            workbook.WorkbookPart.Workbook.Sheets = new DocumentFormat.OpenXml.Spreadsheet.Sheets();

            int iCounter = 0;

            foreach (System.Data.DataTable table in ds.Tables)
            {
                var sheetPart = workbook.WorkbookPart.AddNewPart<WorksheetPart>();
                var sheetData = new DocumentFormat.OpenXml.Spreadsheet.SheetData();
                sheetPart.Worksheet = new DocumentFormat.OpenXml.Spreadsheet.Worksheet(sheetData);

                if (iCounter == 0)
                {
                    var stylesPart = workbook.WorkbookPart.AddNewPart<WorkbookStylesPart>();
                    stylesPart.Stylesheet = new Stylesheet();

                    // blank font list
                    stylesPart.Stylesheet.Fonts = new Fonts();
                    stylesPart.Stylesheet.Fonts.Count = 1;//Because we add only one empty
                    stylesPart.Stylesheet.Fonts.AppendChild(new Font());
                    stylesPart.Stylesheet.Fills = new Fills();

                    var solidRed = new PatternFill() { PatternType = PatternValues.Solid };
                    solidRed.ForegroundColor = new ForegroundColor { Rgb = HexBinaryValue.FromString("FFFF0000") };
                    solidRed.BackgroundColor = new BackgroundColor { Indexed = 64 };

                    var solidYellow = new PatternFill() { PatternType = PatternValues.Solid };
                    solidYellow.ForegroundColor = new ForegroundColor { Rgb = HexBinaryValue.FromString("FFEAFF00") };
                    solidYellow.BackgroundColor = new BackgroundColor { Rgb = HexBinaryValue.FromString("FFEAFF00") };

                    var solidGreen = new PatternFill() { PatternType = PatternValues.Solid };
                    solidGreen.ForegroundColor = new ForegroundColor { Rgb = HexBinaryValue.FromString("FF0EC704") };
                    solidGreen.BackgroundColor = new BackgroundColor { Rgb = HexBinaryValue.FromString("FF0EC704") };

                    var firstFill = stylesPart.Stylesheet.Fills.AppendChild(new Fill { PatternFill = new PatternFill { PatternType = PatternValues.None } }); // required, reserved by Excel
                    stylesPart.Stylesheet.Fills.AppendChild(new Fill { PatternFill = new PatternFill { PatternType = PatternValues.Gray125 } }); // required, reserved by Excel
                    stylesPart.Stylesheet.Fills.AppendChild(new Fill { PatternFill = solidRed });
                    stylesPart.Stylesheet.Fills.AppendChild(new Fill { PatternFill = solidYellow });
                    stylesPart.Stylesheet.Fills.AppendChild(new Fill { PatternFill = solidGreen });
                    stylesPart.Stylesheet.Fills.Count = 5;

                    // blank border list
                    stylesPart.Stylesheet.Borders = new Borders();
                    stylesPart.Stylesheet.Borders.Count = 1;
                    stylesPart.Stylesheet.Borders.AppendChild(new Border());

                    // blank cell format list
                    stylesPart.Stylesheet.CellStyleFormats = new CellStyleFormats();
                    stylesPart.Stylesheet.CellStyleFormats.Count = 1;
                    stylesPart.Stylesheet.CellStyleFormats.AppendChild(new CellFormat());

                    // cell format list
                    stylesPart.Stylesheet.CellFormats = new CellFormats();
                    // empty one for index 0, seems to be required
                    stylesPart.Stylesheet.CellFormats.AppendChild(new CellFormat());
                    // cell format references style format 0, font 0, border 0, fill 2 and applies the fill
                    var redCellStyle = stylesPart.Stylesheet.CellFormats.AppendChild(new CellFormat { FormatId = 0, FontId = 0, BorderId = 0, FillId = 2, ApplyFill = true }).AppendChild(new Alignment { Horizontal = HorizontalAlignmentValues.Center });
                    var yellowCellStyle = stylesPart.Stylesheet.CellFormats.AppendChild(new CellFormat { FormatId = 0, FontId = 0, BorderId = 0, FillId = 3, ApplyFill = true }).AppendChild(new Alignment { Horizontal = HorizontalAlignmentValues.Center });
                    var greenCellStyle = stylesPart.Stylesheet.CellFormats.AppendChild(new CellFormat { FormatId = 0, FontId = 0, BorderId = 0, FillId = 4, ApplyFill = true }).AppendChild(new Alignment { Horizontal = HorizontalAlignmentValues.Center });
                    stylesPart.Stylesheet.CellFormats.Count = 4;

                    stylesPart.Stylesheet.Save();
                }
                iCounter++;

                DocumentFormat.OpenXml.Spreadsheet.Sheets sheets = workbook.WorkbookPart.Workbook.GetFirstChild<DocumentFormat.OpenXml.Spreadsheet.Sheets>();
                string relationshipId = workbook.WorkbookPart.GetIdOfPart(sheetPart);

                uint sheetId = 1;
                if (sheets.Elements<DocumentFormat.OpenXml.Spreadsheet.Sheet>().Count() > 0)
                {
                    sheetId =
                        sheets.Elements<DocumentFormat.OpenXml.Spreadsheet.Sheet>().Select(s => s.SheetId.Value).Max() + 1;
                }

                DocumentFormat.OpenXml.Spreadsheet.Sheet sheet = new DocumentFormat.OpenXml.Spreadsheet.Sheet() { Id = relationshipId, SheetId = sheetId, Name = tableName?? table.TableName };
                sheets.Append(sheet);

                DocumentFormat.OpenXml.Spreadsheet.Row headerRow = new DocumentFormat.OpenXml.Spreadsheet.Row();

                List<string> columns = new List<string>();
                foreach (System.Data.DataColumn column in table.Columns)
                {
                    columns.Add(column.ColumnName);

                    DocumentFormat.OpenXml.Spreadsheet.Cell cell = new DocumentFormat.OpenXml.Spreadsheet.Cell();
                    cell.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.String;
                    cell.CellValue = new DocumentFormat.OpenXml.Spreadsheet.CellValue(column.ColumnName);
                    headerRow.AppendChild(cell);
                }


                sheetData.AppendChild(headerRow);

                foreach (System.Data.DataRow dsrow in table.Rows)
                {
                    DocumentFormat.OpenXml.Spreadsheet.Row newRow = new DocumentFormat.OpenXml.Spreadsheet.Row();
                    foreach (string col in columns)
                    {
                        DocumentFormat.OpenXml.Spreadsheet.Cell cell = new DocumentFormat.OpenXml.Spreadsheet.Cell();
                        cell.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.String;
                        var valueToInsert = dsrow[col].ToString();
                        cell.CellValue = new DocumentFormat.OpenXml.Spreadsheet.CellValue(valueToInsert); //
                        if(col == "Flag")
                        {
                            if (valueToInsert == "RED")
                                cell.StyleIndex = 1;
                            else if (valueToInsert == "GREEN")
                                cell.StyleIndex = 3;
                            else
                                cell.StyleIndex = 2;
                        }
                        newRow.AppendChild(cell);
                    }

                    sheetData.AppendChild(newRow);
                }
            }
        }

        private void CreateParts(SpreadsheetDocument document)
        {
            WorkbookPart workbookPart1 = document.AddWorkbookPart();
            //Id First Sheet rId3
            //Id Second Sheet rId4
            GenerateWorkbookMainContentsAndSheets(workbookPart1);

            WorkbookStylesPart workbookStylesPart1 = workbookPart1.AddNewPart<WorkbookStylesPart>("rId1");
            GenerateWorkbookStylesPart1Content(workbookStylesPart1);

            SharedStringTablePart sharedStringTablePart1 = workbookPart1.AddNewPart<SharedStringTablePart>("rId2");
            GenerateSharedStringTablePart1Content(sharedStringTablePart1);

            WorksheetPart worksheetPart1 = workbookPart1.AddNewPart<WorksheetPart>("rId3");
            GenerateWorksheetPart1Content(worksheetPart1);

            DrawingsPart drawingsPart1 = worksheetPart1.AddNewPart<DrawingsPart>("rId1");
            GenerateDrawingsPart1Content(drawingsPart1);

            WorksheetPart worksheetPart2 = workbookPart1.AddNewPart<WorksheetPart>("rId4");
            GenerateWorksheetPart2Content(worksheetPart2);

            DrawingsPart drawingsPart2 = worksheetPart2.AddNewPart<DrawingsPart>("rId1");
            GenerateDrawingsPart2Content(drawingsPart2);

            SetPackageProperties(document);
        }

        // Generates content of workbookPart1.
        private void GenerateWorkbookMainContentsAndSheets(WorkbookPart workbookPart1)
        {
            Workbook workbook1 = new Workbook();
            workbook1.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            workbook1.AddNamespaceDeclaration("mx", "http://schemas.microsoft.com/office/mac/excel/2008/main");
            workbook1.AddNamespaceDeclaration("mc", "http://schemas.openxmlformats.org/markup-compatibility/2006");
            workbook1.AddNamespaceDeclaration("mv", "urn:schemas-microsoft-com:mac:vml");
            workbook1.AddNamespaceDeclaration("x14", "http://schemas.microsoft.com/office/spreadsheetml/2009/9/main");
            workbook1.AddNamespaceDeclaration("x14ac", "http://schemas.microsoft.com/office/spreadsheetml/2009/9/ac");
            workbook1.AddNamespaceDeclaration("xm", "http://schemas.microsoft.com/office/excel/2006/main");
            WorkbookProperties workbookProperties1 = new WorkbookProperties();

            Sheets sheets1 = new Sheets();
            Sheet sheet1 = new Sheet() { Name = "First Sheet", SheetId = (UInt32Value)1U, State = SheetStateValues.Visible, Id = "rId3" };
            Sheet sheet2 = new Sheet() { Name = "Outra Folha", SheetId = (UInt32Value)2U, State = SheetStateValues.Visible, Id = "rId4" };

            sheets1.Append(sheet1);
            sheets1.Append(sheet2);
            DefinedNames definedNames1 = new DefinedNames();
            CalculationProperties calculationProperties1 = new CalculationProperties();

            workbook1.Append(workbookProperties1);
            workbook1.Append(sheets1);
            workbook1.Append(definedNames1);
            workbook1.Append(calculationProperties1);

            workbookPart1.Workbook = workbook1;
        }
        // Generates content of workbookStylesPart1.

        private void GenerateWorkbookStylesPart1Content(WorkbookStylesPart workbookStylesPart1)
        {
            Stylesheet stylesheet1 = new Stylesheet();
            stylesheet1.AddNamespaceDeclaration("x14ac", "http://schemas.microsoft.com/office/spreadsheetml/2009/9/ac");
            stylesheet1.AddNamespaceDeclaration("mc", "http://schemas.openxmlformats.org/markup-compatibility/2006");

            Fonts fonts1 = new Fonts() { Count = (UInt32Value)4U };

            Font font1 = new Font();
            FontSize fontSize1 = new FontSize() { Val = 10.0D };
            Color color1 = new Color() { Rgb = "FF000000" };
            FontName fontName1 = new FontName() { Val = "Arial" };

            font1.Append(fontSize1);
            font1.Append(color1);
            font1.Append(fontName1);

            Font font2 = new Font();
            Bold bold1 = new Bold();
            Color color2 = new Color() { Rgb = "FFFFFFFF" };

            font2.Append(bold1);
            font2.Append(color2);
            Font font3 = new Font();

            Font font4 = new Font();
            Bold bold2 = new Bold();

            font4.Append(bold2);

            fonts1.Append(font1);
            fonts1.Append(font2);
            fonts1.Append(font3);
            fonts1.Append(font4);

            Fills fills1 = new Fills() { Count = (UInt32Value)5U };

            Fill fill1 = new Fill();
            PatternFill patternFill1 = new PatternFill() { PatternType = PatternValues.None };

            fill1.Append(patternFill1);

            Fill fill2 = new Fill();
            PatternFill patternFill2 = new PatternFill() { PatternType = PatternValues.LightGray };

            fill2.Append(patternFill2);

            Fill fill3 = new Fill();

            PatternFill patternFill3 = new PatternFill() { PatternType = PatternValues.Solid };
            ForegroundColor foregroundColor1 = new ForegroundColor() { Rgb = "FF434343" };
            BackgroundColor backgroundColor1 = new BackgroundColor() { Rgb = "FF434343" };

            patternFill3.Append(foregroundColor1);
            patternFill3.Append(backgroundColor1);

            fill3.Append(patternFill3);

            Fill fill4 = new Fill();

            PatternFill patternFill4 = new PatternFill() { PatternType = PatternValues.Solid };
            ForegroundColor foregroundColor2 = new ForegroundColor() { Rgb = "FFFFFF00" };
            BackgroundColor backgroundColor2 = new BackgroundColor() { Rgb = "FFFFFF00" };

            patternFill4.Append(foregroundColor2);
            patternFill4.Append(backgroundColor2);

            fill4.Append(patternFill4);

            Fill fill5 = new Fill();

            PatternFill patternFill5 = new PatternFill() { PatternType = PatternValues.Solid };
            ForegroundColor foregroundColor3 = new ForegroundColor() { Rgb = "FF000000" };
            BackgroundColor backgroundColor3 = new BackgroundColor() { Rgb = "FF000000" };

            patternFill5.Append(foregroundColor3);
            patternFill5.Append(backgroundColor3);

            fill5.Append(patternFill5);

            fills1.Append(fill1);
            fills1.Append(fill2);
            fills1.Append(fill3);
            fills1.Append(fill4);
            fills1.Append(fill5);

            Borders borders1 = new Borders() { Count = (UInt32Value)5U };

            Border border1 = new Border();
            LeftBorder leftBorder1 = new LeftBorder();
            RightBorder rightBorder1 = new RightBorder();
            TopBorder topBorder1 = new TopBorder();
            BottomBorder bottomBorder1 = new BottomBorder();

            border1.Append(leftBorder1);
            border1.Append(rightBorder1);
            border1.Append(topBorder1);
            border1.Append(bottomBorder1);

            Border border2 = new Border();

            LeftBorder leftBorder2 = new LeftBorder() { Style = BorderStyleValues.Thin };
            Color color3 = new Color() { Rgb = "FF000000" };

            leftBorder2.Append(color3);
            RightBorder rightBorder2 = new RightBorder();

            TopBorder topBorder2 = new TopBorder() { Style = BorderStyleValues.Thin };
            Color color4 = new Color() { Rgb = "FF000000" };

            topBorder2.Append(color4);

            BottomBorder bottomBorder2 = new BottomBorder() { Style = BorderStyleValues.Thin };
            Color color5 = new Color() { Rgb = "FF000000" };

            bottomBorder2.Append(color5);

            border2.Append(leftBorder2);
            border2.Append(rightBorder2);
            border2.Append(topBorder2);
            border2.Append(bottomBorder2);

            Border border3 = new Border();
            LeftBorder leftBorder3 = new LeftBorder();
            RightBorder rightBorder3 = new RightBorder();

            TopBorder topBorder3 = new TopBorder() { Style = BorderStyleValues.Thin };
            Color color6 = new Color() { Rgb = "FF000000" };

            topBorder3.Append(color6);

            BottomBorder bottomBorder3 = new BottomBorder() { Style = BorderStyleValues.Thin };
            Color color7 = new Color() { Rgb = "FF000000" };

            bottomBorder3.Append(color7);

            border3.Append(leftBorder3);
            border3.Append(rightBorder3);
            border3.Append(topBorder3);
            border3.Append(bottomBorder3);

            Border border4 = new Border();
            LeftBorder leftBorder4 = new LeftBorder();

            RightBorder rightBorder4 = new RightBorder() { Style = BorderStyleValues.Thin };
            Color color8 = new Color() { Rgb = "FF000000" };

            rightBorder4.Append(color8);

            TopBorder topBorder4 = new TopBorder() { Style = BorderStyleValues.Thin };
            Color color9 = new Color() { Rgb = "FF000000" };

            topBorder4.Append(color9);

            BottomBorder bottomBorder4 = new BottomBorder() { Style = BorderStyleValues.Thin };
            Color color10 = new Color() { Rgb = "FF000000" };

            bottomBorder4.Append(color10);

            border4.Append(leftBorder4);
            border4.Append(rightBorder4);
            border4.Append(topBorder4);
            border4.Append(bottomBorder4);

            Border border5 = new Border();

            LeftBorder leftBorder5 = new LeftBorder() { Style = BorderStyleValues.Thin };
            Color color11 = new Color() { Rgb = "FF000000" };

            leftBorder5.Append(color11);

            RightBorder rightBorder5 = new RightBorder() { Style = BorderStyleValues.Thin };
            Color color12 = new Color() { Rgb = "FF000000" };

            rightBorder5.Append(color12);

            TopBorder topBorder5 = new TopBorder() { Style = BorderStyleValues.Thin };
            Color color13 = new Color() { Rgb = "FF000000" };

            topBorder5.Append(color13);

            BottomBorder bottomBorder5 = new BottomBorder() { Style = BorderStyleValues.Thin };
            Color color14 = new Color() { Rgb = "FF000000" };

            bottomBorder5.Append(color14);

            border5.Append(leftBorder5);
            border5.Append(rightBorder5);
            border5.Append(topBorder5);
            border5.Append(bottomBorder5);

            borders1.Append(border1);
            borders1.Append(border2);
            borders1.Append(border3);
            borders1.Append(border4);
            borders1.Append(border5);

            CellStyleFormats cellStyleFormats1 = new CellStyleFormats() { Count = (UInt32Value)1U };
            CellFormat cellFormat1 = new CellFormat() { NumberFormatId = (UInt32Value)0U, FontId = (UInt32Value)0U, FillId = (UInt32Value)0U, BorderId = (UInt32Value)0U, ApplyFont = true, ApplyAlignment = true };

            cellStyleFormats1.Append(cellFormat1);

            CellFormats cellFormats1 = new CellFormats() { Count = (UInt32Value)7U };

            CellFormat cellFormat2 = new CellFormat() { NumberFormatId = (UInt32Value)0U, FontId = (UInt32Value)0U, FillId = (UInt32Value)0U, BorderId = (UInt32Value)0U, FormatId = (UInt32Value)0U, ApplyFont = true, ApplyAlignment = true };
            Alignment alignment1 = new Alignment();

            cellFormat2.Append(alignment1);

            CellFormat cellFormat3 = new CellFormat() { NumberFormatId = (UInt32Value)0U, FontId = (UInt32Value)1U, FillId = (UInt32Value)2U, BorderId = (UInt32Value)1U, FormatId = (UInt32Value)0U, ApplyFont = true, ApplyFill = true, ApplyBorder = true, ApplyAlignment = true };
            Alignment alignment2 = new Alignment() { Horizontal = HorizontalAlignmentValues.Center };

            cellFormat3.Append(alignment2);
            CellFormat cellFormat4 = new CellFormat() { NumberFormatId = (UInt32Value)0U, FontId = (UInt32Value)2U, FillId = (UInt32Value)0U, BorderId = (UInt32Value)2U, FormatId = (UInt32Value)0U, ApplyFont = true, ApplyBorder = true };
            CellFormat cellFormat5 = new CellFormat() { NumberFormatId = (UInt32Value)0U, FontId = (UInt32Value)2U, FillId = (UInt32Value)0U, BorderId = (UInt32Value)3U, FormatId = (UInt32Value)0U, ApplyFont = true, ApplyBorder = true };

            CellFormat cellFormat6 = new CellFormat() { NumberFormatId = (UInt32Value)0U, FontId = (UInt32Value)3U, FillId = (UInt32Value)3U, BorderId = (UInt32Value)4U, FormatId = (UInt32Value)0U, ApplyFont = true, ApplyFill = true, ApplyBorder = true, ApplyAlignment = true };
            Alignment alignment3 = new Alignment();

            cellFormat6.Append(alignment3);

            CellFormat cellFormat7 = new CellFormat() { NumberFormatId = (UInt32Value)0U, FontId = (UInt32Value)2U, FillId = (UInt32Value)0U, BorderId = (UInt32Value)4U, FormatId = (UInt32Value)0U, ApplyFont = true, ApplyBorder = true, ApplyAlignment = true };
            Alignment alignment4 = new Alignment();

            cellFormat7.Append(alignment4);

            CellFormat cellFormat8 = new CellFormat() { NumberFormatId = (UInt32Value)0U, FontId = (UInt32Value)1U, FillId = (UInt32Value)4U, BorderId = (UInt32Value)1U, FormatId = (UInt32Value)0U, ApplyFont = true, ApplyFill = true, ApplyBorder = true, ApplyAlignment = true };
            Alignment alignment5 = new Alignment() { Horizontal = HorizontalAlignmentValues.Center };

            cellFormat8.Append(alignment5);

            cellFormats1.Append(cellFormat2);
            cellFormats1.Append(cellFormat3);
            cellFormats1.Append(cellFormat4);
            cellFormats1.Append(cellFormat5);
            cellFormats1.Append(cellFormat6);
            cellFormats1.Append(cellFormat7);
            cellFormats1.Append(cellFormat8);

            CellStyles cellStyles1 = new CellStyles() { Count = (UInt32Value)1U };
            CellStyle cellStyle1 = new CellStyle() { Name = "Normal", FormatId = (UInt32Value)0U, BuiltinId = (UInt32Value)0U };

            cellStyles1.Append(cellStyle1);
            DifferentialFormats differentialFormats1 = new DifferentialFormats() { Count = (UInt32Value)0U };

            stylesheet1.Append(fonts1);
            stylesheet1.Append(fills1);
            stylesheet1.Append(borders1);
            stylesheet1.Append(cellStyleFormats1);
            stylesheet1.Append(cellFormats1);
            stylesheet1.Append(cellStyles1);
            stylesheet1.Append(differentialFormats1);

            workbookStylesPart1.Stylesheet = stylesheet1;
        }

        // Generates content of sharedStringTablePart1.
        private void GenerateSharedStringTablePart1Content(SharedStringTablePart sharedStringTablePart1)
        {
            SharedStringTable sharedStringTable1 = new SharedStringTable() { Count = (UInt32Value)26U, UniqueCount = (UInt32Value)26U };

            SharedStringItem sharedStringItem1 = new SharedStringItem();
            Text text1 = new Text();
            text1.Text = "A title table";

            sharedStringItem1.Append(text1);

            SharedStringItem sharedStringItem2 = new SharedStringItem();
            Text text2 = new Text();
            text2.Text = "Column 1";

            sharedStringItem2.Append(text2);

            SharedStringItem sharedStringItem3 = new SharedStringItem();
            Text text3 = new Text();
            text3.Text = "Column 2";

            sharedStringItem3.Append(text3);

            SharedStringItem sharedStringItem4 = new SharedStringItem();
            Text text4 = new Text();
            text4.Text = "Column 3";

            sharedStringItem4.Append(text4);

            SharedStringItem sharedStringItem5 = new SharedStringItem();
            Text text5 = new Text();
            text5.Text = "A1";

            sharedStringItem5.Append(text5);

            SharedStringItem sharedStringItem6 = new SharedStringItem();
            Text text6 = new Text();
            text6.Text = "B1";

            sharedStringItem6.Append(text6);

            SharedStringItem sharedStringItem7 = new SharedStringItem();
            Text text7 = new Text();
            text7.Text = "C1";

            sharedStringItem7.Append(text7);

            SharedStringItem sharedStringItem8 = new SharedStringItem();
            Text text8 = new Text();
            text8.Text = "A2";

            sharedStringItem8.Append(text8);

            SharedStringItem sharedStringItem9 = new SharedStringItem();
            Text text9 = new Text();
            text9.Text = "B2";

            sharedStringItem9.Append(text9);

            SharedStringItem sharedStringItem10 = new SharedStringItem();
            Text text10 = new Text();
            text10.Text = "C2";

            sharedStringItem10.Append(text10);

            SharedStringItem sharedStringItem11 = new SharedStringItem();
            Text text11 = new Text();
            text11.Text = "A3";

            sharedStringItem11.Append(text11);

            SharedStringItem sharedStringItem12 = new SharedStringItem();
            Text text12 = new Text();
            text12.Text = "B3";

            sharedStringItem12.Append(text12);

            SharedStringItem sharedStringItem13 = new SharedStringItem();
            Text text13 = new Text();
            text13.Text = "C3";

            sharedStringItem13.Append(text13);

            SharedStringItem sharedStringItem14 = new SharedStringItem();
            Text text14 = new Text();
            text14.Text = "Another Title for Table";

            sharedStringItem14.Append(text14);

            SharedStringItem sharedStringItem15 = new SharedStringItem();
            Text text15 = new Text();
            text15.Text = "A";

            sharedStringItem15.Append(text15);

            SharedStringItem sharedStringItem16 = new SharedStringItem();
            Text text16 = new Text();
            text16.Text = "B";

            sharedStringItem16.Append(text16);

            SharedStringItem sharedStringItem17 = new SharedStringItem();
            Text text17 = new Text();
            text17.Text = "C";

            sharedStringItem17.Append(text17);

            SharedStringItem sharedStringItem18 = new SharedStringItem();
            Text text18 = new Text();
            text18.Text = "1a";

            sharedStringItem18.Append(text18);

            SharedStringItem sharedStringItem19 = new SharedStringItem();
            Text text19 = new Text();
            text19.Text = "2b";

            sharedStringItem19.Append(text19);

            SharedStringItem sharedStringItem20 = new SharedStringItem();
            Text text20 = new Text();
            text20.Text = "3c";

            sharedStringItem20.Append(text20);

            SharedStringItem sharedStringItem21 = new SharedStringItem();
            Text text21 = new Text();
            text21.Text = "1b";

            sharedStringItem21.Append(text21);

            SharedStringItem sharedStringItem22 = new SharedStringItem();
            Text text22 = new Text();
            text22.Text = "2c";

            sharedStringItem22.Append(text22);

            SharedStringItem sharedStringItem23 = new SharedStringItem();
            Text text23 = new Text();
            text23.Text = "3d";

            sharedStringItem23.Append(text23);

            SharedStringItem sharedStringItem24 = new SharedStringItem();
            Text text24 = new Text();
            text24.Text = "1c";

            sharedStringItem24.Append(text24);

            SharedStringItem sharedStringItem25 = new SharedStringItem();
            Text text25 = new Text();
            text25.Text = "2d";

            sharedStringItem25.Append(text25);

            SharedStringItem sharedStringItem26 = new SharedStringItem();
            Text text26 = new Text();
            text26.Text = "3e";

            sharedStringItem26.Append(text26);

            sharedStringTable1.Append(sharedStringItem1);
            sharedStringTable1.Append(sharedStringItem2);
            sharedStringTable1.Append(sharedStringItem3);
            sharedStringTable1.Append(sharedStringItem4);
            sharedStringTable1.Append(sharedStringItem5);
            sharedStringTable1.Append(sharedStringItem6);
            sharedStringTable1.Append(sharedStringItem7);
            sharedStringTable1.Append(sharedStringItem8);
            sharedStringTable1.Append(sharedStringItem9);
            sharedStringTable1.Append(sharedStringItem10);
            sharedStringTable1.Append(sharedStringItem11);
            sharedStringTable1.Append(sharedStringItem12);
            sharedStringTable1.Append(sharedStringItem13);
            sharedStringTable1.Append(sharedStringItem14);
            sharedStringTable1.Append(sharedStringItem15);
            sharedStringTable1.Append(sharedStringItem16);
            sharedStringTable1.Append(sharedStringItem17);
            sharedStringTable1.Append(sharedStringItem18);
            sharedStringTable1.Append(sharedStringItem19);
            sharedStringTable1.Append(sharedStringItem20);
            sharedStringTable1.Append(sharedStringItem21);
            sharedStringTable1.Append(sharedStringItem22);
            sharedStringTable1.Append(sharedStringItem23);
            sharedStringTable1.Append(sharedStringItem24);
            sharedStringTable1.Append(sharedStringItem25);
            sharedStringTable1.Append(sharedStringItem26);

            sharedStringTablePart1.SharedStringTable = sharedStringTable1;
        }

        // Generates content of worksheetPart1.
        private void GenerateWorksheetPart1Content(WorksheetPart worksheetPart1)
        {
            Worksheet worksheet1 = new Worksheet();
            worksheet1.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            worksheet1.AddNamespaceDeclaration("mx", "http://schemas.microsoft.com/office/mac/excel/2008/main");
            worksheet1.AddNamespaceDeclaration("mc", "http://schemas.openxmlformats.org/markup-compatibility/2006");
            worksheet1.AddNamespaceDeclaration("mv", "urn:schemas-microsoft-com:mac:vml");
            worksheet1.AddNamespaceDeclaration("x14", "http://schemas.microsoft.com/office/spreadsheetml/2009/9/main");
            worksheet1.AddNamespaceDeclaration("x14ac", "http://schemas.microsoft.com/office/spreadsheetml/2009/9/ac");
            worksheet1.AddNamespaceDeclaration("xm", "http://schemas.microsoft.com/office/excel/2006/main");

            SheetViews sheetViews1 = new SheetViews();
            SheetView sheetView1 = new SheetView() { WorkbookViewId = (UInt32Value)0U };

            sheetViews1.Append(sheetView1);
            SheetFormatProperties sheetFormatProperties1 = new SheetFormatProperties() { DefaultColumnWidth = 14.43D, DefaultRowHeight = 15.75D, CustomHeight = true };

            SheetData sheetData1 = new SheetData();

            Row row1 = new Row() { RowIndex = (UInt32Value)3U };

            Cell cell1 = new Cell() { CellReference = "B3", StyleIndex = (UInt32Value)1U, DataType = CellValues.SharedString };
            CellValue cellValue1 = new CellValue();
            cellValue1.Text = "0";

            cell1.Append(cellValue1);
            Cell cell2 = new Cell() { CellReference = "C3", StyleIndex = (UInt32Value)2U };
            Cell cell3 = new Cell() { CellReference = "D3", StyleIndex = (UInt32Value)3U };

            row1.Append(cell1);
            row1.Append(cell2);
            row1.Append(cell3);

            Row row2 = new Row() { RowIndex = (UInt32Value)4U };

            Cell cell4 = new Cell() { CellReference = "B4", StyleIndex = (UInt32Value)4U, DataType = CellValues.SharedString };
            CellValue cellValue2 = new CellValue();
            cellValue2.Text = "1";

            cell4.Append(cellValue2);

            Cell cell5 = new Cell() { CellReference = "C4", StyleIndex = (UInt32Value)4U, DataType = CellValues.SharedString };
            CellValue cellValue3 = new CellValue();
            cellValue3.Text = "2";

            cell5.Append(cellValue3);

            Cell cell6 = new Cell() { CellReference = "D4", StyleIndex = (UInt32Value)4U, DataType = CellValues.SharedString };
            CellValue cellValue4 = new CellValue();
            cellValue4.Text = "3";

            cell6.Append(cellValue4);

            row2.Append(cell4);
            row2.Append(cell5);
            row2.Append(cell6);

            Row row3 = new Row() { RowIndex = (UInt32Value)5U };

            Cell cell7 = new Cell() { CellReference = "B5", StyleIndex = (UInt32Value)5U, DataType = CellValues.SharedString };
            CellValue cellValue5 = new CellValue();
            cellValue5.Text = "4";

            cell7.Append(cellValue5);

            Cell cell8 = new Cell() { CellReference = "C5", StyleIndex = (UInt32Value)5U, DataType = CellValues.SharedString };
            CellValue cellValue6 = new CellValue();
            cellValue6.Text = "5";

            cell8.Append(cellValue6);

            Cell cell9 = new Cell() { CellReference = "D5", StyleIndex = (UInt32Value)5U, DataType = CellValues.SharedString };
            CellValue cellValue7 = new CellValue();
            cellValue7.Text = "6";

            cell9.Append(cellValue7);

            row3.Append(cell7);
            row3.Append(cell8);
            row3.Append(cell9);

            Row row4 = new Row() { RowIndex = (UInt32Value)6U };

            Cell cell10 = new Cell() { CellReference = "B6", StyleIndex = (UInt32Value)5U, DataType = CellValues.SharedString };
            CellValue cellValue8 = new CellValue();
            cellValue8.Text = "7";

            cell10.Append(cellValue8);

            Cell cell11 = new Cell() { CellReference = "C6", StyleIndex = (UInt32Value)5U, DataType = CellValues.SharedString };
            CellValue cellValue9 = new CellValue();
            cellValue9.Text = "8";

            cell11.Append(cellValue9);

            Cell cell12 = new Cell() { CellReference = "D6", StyleIndex = (UInt32Value)5U, DataType = CellValues.SharedString };
            CellValue cellValue10 = new CellValue();
            cellValue10.Text = "9";

            cell12.Append(cellValue10);

            row4.Append(cell10);
            row4.Append(cell11);
            row4.Append(cell12);

            Row row5 = new Row() { RowIndex = (UInt32Value)7U };

            Cell cell13 = new Cell() { CellReference = "B7", StyleIndex = (UInt32Value)5U, DataType = CellValues.SharedString };
            CellValue cellValue11 = new CellValue();
            cellValue11.Text = "10";

            cell13.Append(cellValue11);

            Cell cell14 = new Cell() { CellReference = "C7", StyleIndex = (UInt32Value)5U, DataType = CellValues.SharedString };
            CellValue cellValue12 = new CellValue();
            cellValue12.Text = "11";

            cell14.Append(cellValue12);

            Cell cell15 = new Cell() { CellReference = "D7", StyleIndex = (UInt32Value)5U, DataType = CellValues.SharedString };
            CellValue cellValue13 = new CellValue();
            cellValue13.Text = "12";

            cell15.Append(cellValue13);

            row5.Append(cell13);
            row5.Append(cell14);
            row5.Append(cell15);

            sheetData1.Append(row1);
            sheetData1.Append(row2);
            sheetData1.Append(row3);
            sheetData1.Append(row4);
            sheetData1.Append(row5);

            MergeCells mergeCells1 = new MergeCells() { Count = (UInt32Value)1U };
            MergeCell mergeCell1 = new MergeCell() { Reference = "B3:D3" };

            mergeCells1.Append(mergeCell1);
            Drawing drawing1 = new Drawing() { Id = "rId1" };

            worksheet1.Append(sheetViews1);
            worksheet1.Append(sheetFormatProperties1);
            worksheet1.Append(sheetData1);
            worksheet1.Append(mergeCells1);
            worksheet1.Append(drawing1);

            worksheetPart1.Worksheet = worksheet1;
        }

        // Generates content of drawingsPart1.
        private void GenerateDrawingsPart1Content(DrawingsPart drawingsPart1)
        {
            Xdr.WorksheetDrawing worksheetDrawing1 = new Xdr.WorksheetDrawing();
            worksheetDrawing1.AddNamespaceDeclaration("xdr", "http://schemas.openxmlformats.org/drawingml/2006/spreadsheetDrawing");
            worksheetDrawing1.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");
            worksheetDrawing1.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            worksheetDrawing1.AddNamespaceDeclaration("c", "http://schemas.openxmlformats.org/drawingml/2006/chart");
            worksheetDrawing1.AddNamespaceDeclaration("mc", "http://schemas.openxmlformats.org/markup-compatibility/2006");
            worksheetDrawing1.AddNamespaceDeclaration("dgm", "http://schemas.openxmlformats.org/drawingml/2006/diagram");

            drawingsPart1.WorksheetDrawing = worksheetDrawing1;
        }

        // Generates content of worksheetPart2.
        private void GenerateWorksheetPart2Content(WorksheetPart worksheetPart2)
        {
            Worksheet worksheet2 = new Worksheet();
            worksheet2.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            worksheet2.AddNamespaceDeclaration("mx", "http://schemas.microsoft.com/office/mac/excel/2008/main");
            worksheet2.AddNamespaceDeclaration("mc", "http://schemas.openxmlformats.org/markup-compatibility/2006");
            worksheet2.AddNamespaceDeclaration("mv", "urn:schemas-microsoft-com:mac:vml");
            worksheet2.AddNamespaceDeclaration("x14", "http://schemas.microsoft.com/office/spreadsheetml/2009/9/main");
            worksheet2.AddNamespaceDeclaration("x14ac", "http://schemas.microsoft.com/office/spreadsheetml/2009/9/ac");
            worksheet2.AddNamespaceDeclaration("xm", "http://schemas.microsoft.com/office/excel/2006/main");

            SheetViews sheetViews2 = new SheetViews();
            SheetView sheetView2 = new SheetView() { WorkbookViewId = (UInt32Value)0U };

            sheetViews2.Append(sheetView2);
            SheetFormatProperties sheetFormatProperties2 = new SheetFormatProperties() { DefaultColumnWidth = 14.43D, DefaultRowHeight = 15.75D, CustomHeight = true };

            SheetData sheetData2 = new SheetData();

            Row row6 = new Row() { RowIndex = (UInt32Value)2U };

            Cell cell16 = new Cell() { CellReference = "B2", StyleIndex = (UInt32Value)6U, DataType = CellValues.SharedString };
            CellValue cellValue14 = new CellValue();
            cellValue14.Text = "13";

            cell16.Append(cellValue14);
            Cell cell17 = new Cell() { CellReference = "C2", StyleIndex = (UInt32Value)2U };
            Cell cell18 = new Cell() { CellReference = "D2", StyleIndex = (UInt32Value)3U };

            row6.Append(cell16);
            row6.Append(cell17);
            row6.Append(cell18);

            Row row7 = new Row() { RowIndex = (UInt32Value)3U };

            Cell cell19 = new Cell() { CellReference = "B3", StyleIndex = (UInt32Value)4U, DataType = CellValues.SharedString };
            CellValue cellValue15 = new CellValue();
            cellValue15.Text = "14";

            cell19.Append(cellValue15);

            Cell cell20 = new Cell() { CellReference = "C3", StyleIndex = (UInt32Value)4U, DataType = CellValues.SharedString };
            CellValue cellValue16 = new CellValue();
            cellValue16.Text = "15";

            cell20.Append(cellValue16);

            Cell cell21 = new Cell() { CellReference = "D3", StyleIndex = (UInt32Value)4U, DataType = CellValues.SharedString };
            CellValue cellValue17 = new CellValue();
            cellValue17.Text = "16";

            cell21.Append(cellValue17);

            row7.Append(cell19);
            row7.Append(cell20);
            row7.Append(cell21);

            Row row8 = new Row() { RowIndex = (UInt32Value)4U };

            Cell cell22 = new Cell() { CellReference = "B4", StyleIndex = (UInt32Value)5U, DataType = CellValues.SharedString };
            CellValue cellValue18 = new CellValue();
            cellValue18.Text = "17";

            cell22.Append(cellValue18);

            Cell cell23 = new Cell() { CellReference = "C4", StyleIndex = (UInt32Value)5U, DataType = CellValues.SharedString };
            CellValue cellValue19 = new CellValue();
            cellValue19.Text = "18";

            cell23.Append(cellValue19);

            Cell cell24 = new Cell() { CellReference = "D4", StyleIndex = (UInt32Value)5U, DataType = CellValues.SharedString };
            CellValue cellValue20 = new CellValue();
            cellValue20.Text = "19";

            cell24.Append(cellValue20);

            row8.Append(cell22);
            row8.Append(cell23);
            row8.Append(cell24);

            Row row9 = new Row() { RowIndex = (UInt32Value)5U };

            Cell cell25 = new Cell() { CellReference = "B5", StyleIndex = (UInt32Value)5U, DataType = CellValues.SharedString };
            CellValue cellValue21 = new CellValue();
            cellValue21.Text = "20";

            cell25.Append(cellValue21);

            Cell cell26 = new Cell() { CellReference = "C5", StyleIndex = (UInt32Value)5U, DataType = CellValues.SharedString };
            CellValue cellValue22 = new CellValue();
            cellValue22.Text = "21";

            cell26.Append(cellValue22);

            Cell cell27 = new Cell() { CellReference = "D5", StyleIndex = (UInt32Value)5U, DataType = CellValues.SharedString };
            CellValue cellValue23 = new CellValue();
            cellValue23.Text = "22";

            cell27.Append(cellValue23);

            row9.Append(cell25);
            row9.Append(cell26);
            row9.Append(cell27);

            Row row10 = new Row() { RowIndex = (UInt32Value)6U };

            Cell cell28 = new Cell() { CellReference = "B6", StyleIndex = (UInt32Value)5U, DataType = CellValues.SharedString };
            CellValue cellValue24 = new CellValue();
            cellValue24.Text = "23";

            cell28.Append(cellValue24);

            Cell cell29 = new Cell() { CellReference = "C6", StyleIndex = (UInt32Value)5U, DataType = CellValues.SharedString };
            CellValue cellValue25 = new CellValue();
            cellValue25.Text = "24";

            cell29.Append(cellValue25);

            Cell cell30 = new Cell() { CellReference = "D6", StyleIndex = (UInt32Value)5U, DataType = CellValues.SharedString };
            CellValue cellValue26 = new CellValue();
            cellValue26.Text = "25";

            cell30.Append(cellValue26);

            row10.Append(cell28);
            row10.Append(cell29);
            row10.Append(cell30);

            sheetData2.Append(row6);
            sheetData2.Append(row7);
            sheetData2.Append(row8);
            sheetData2.Append(row9);
            sheetData2.Append(row10);

            MergeCells mergeCells2 = new MergeCells() { Count = (UInt32Value)1U };
            MergeCell mergeCell2 = new MergeCell() { Reference = "B2:D2" };

            mergeCells2.Append(mergeCell2);
            Drawing drawing2 = new Drawing() { Id = "rId1" };

            worksheet2.Append(sheetViews2);
            worksheet2.Append(sheetFormatProperties2);
            worksheet2.Append(sheetData2);
            worksheet2.Append(mergeCells2);
            worksheet2.Append(drawing2);

            worksheetPart2.Worksheet = worksheet2;
        }

        // Generates content of drawingsPart2.
        private void GenerateDrawingsPart2Content(DrawingsPart drawingsPart2)
        {
            Xdr.WorksheetDrawing worksheetDrawing2 = new Xdr.WorksheetDrawing();
            worksheetDrawing2.AddNamespaceDeclaration("xdr", "http://schemas.openxmlformats.org/drawingml/2006/spreadsheetDrawing");
            worksheetDrawing2.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");
            worksheetDrawing2.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            worksheetDrawing2.AddNamespaceDeclaration("c", "http://schemas.openxmlformats.org/drawingml/2006/chart");
            worksheetDrawing2.AddNamespaceDeclaration("mc", "http://schemas.openxmlformats.org/markup-compatibility/2006");
            worksheetDrawing2.AddNamespaceDeclaration("dgm", "http://schemas.openxmlformats.org/drawingml/2006/diagram");

            drawingsPart2.WorksheetDrawing = worksheetDrawing2;
        }

        private void SetPackageProperties(OpenXmlPackage document)
        {
        }
    }
}
