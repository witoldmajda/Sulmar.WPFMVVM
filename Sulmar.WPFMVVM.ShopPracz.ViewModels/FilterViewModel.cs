using Sulmar.WPFMVVM.Common;
using Sulmar.WPFMVVM.ShopPracz.Models;
using Sulmar.WPFMVVM.ShopPracz.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Sulmar.WPFMVVM.ShopPracz.ViewModels
{
    public class FilterViewModel : BaseViewModel
    {
        public Filter Filter { get; set; }

        private readonly IFiltersService filtersService;

        public FilterViewModel()
            :this(new MocFiltersService())
        {

        }

        public FilterViewModel(IFiltersService filtersService)
        {
            this.filtersService = filtersService;

            Load();
        }

        private void Load()
        {
            Filter = filtersService.Get(1);
        }

        public ICommand InspectionCommand
        {
            get
            {
                return new RelayCommand(p => Inspection(p), p => CanInspection(p));
            }
          
        }

        private bool CanInspection(object segment)
        {
            return true;
        }

        private void Inspection(object parameter)
        {
            Segment segment = parameter as Segment;
            UpdateSegmentState(segment);
        }

        private static void UpdateSegmentState(Segment segment)
        {
            if (segment.State == SegmentState.OK)
            {
                segment.State = SegmentState.FailureA;
            }
            else
            if (segment.State == SegmentState.FailureA)
            {
                segment.State = SegmentState.FailureB;
            }
            else
            if (segment.State == SegmentState.FailureB)
            {
                segment.State = SegmentState.OK;
            }
        }

    }
}
