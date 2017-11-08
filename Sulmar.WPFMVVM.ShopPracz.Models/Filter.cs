using System;
using System.Collections.Generic;
using System.Text;

namespace Sulmar.WPFMVVM.ShopPracz.Models
{
    public class Filter : Base
    {
        //public string A { get; set; }

        //public string AB { get; set; }

        //public string B { get; set; }

        //public string AC { get; set; }

        //public string BD { get; set; }

        //public string C { get; set; }

        //public string CD { get; set; }

        //public string D { get; set; }

        public int Id { get; set; }

        public string Name { get; set; }

        public IList<Segment> Segments { get; set; }
    }

    public class Segment : Base
    {
        public string Name { get; set; }

        private SegmentState _state;
        public SegmentState State
        {
            get
            {
                return _state;
            }
            set
            {
                _state = value;
                OnPropertyChanged();
            }
        }
    }

    public enum SegmentState
    {
        OK,
        FailureA,
        FailureB
    }
}
