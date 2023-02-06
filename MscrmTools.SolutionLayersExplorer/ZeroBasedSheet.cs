using OfficeOpenXml;

namespace MscrmTools.SolutionLayersExplorer
{
    public static class ZeroBasedSheet
    {
        public static ExcelRange Cell(ExcelWorksheet sheet, int x, int y)
        {
            return sheet.Cells[x + 1, y + 1];
        }
    }
}
