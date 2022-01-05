using System;

namespace MscrmTools.SolutionLayersExplorer.AppCode.Args
{
    public class ComparisonEventArgs
    {
        public string Attribute { get; set; }
        public string Entity { get; set; }
        public Guid Id { get; set; }
        public bool IsSpecific { get; set; }
        public string SpecificType { get; set; }
        public string SpecificValue { get; set; }

        public override string ToString()
        {
            if (IsSpecific)
            {
                return $"{IsSpecific};{SpecificType};{SpecificValue};{Id}";
            }
            else
            {
                return $"{IsSpecific};{Entity};{Attribute};{Id}";
            }
        }
    }
}