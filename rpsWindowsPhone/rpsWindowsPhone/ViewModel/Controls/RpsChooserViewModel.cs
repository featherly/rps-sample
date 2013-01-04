using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using rpsWindowsPhone.Model;

namespace rpsWindowsPhone.ViewModel.Controls
{
    public class RpsChooserViewModel : ViewModelBase
    {
        public RpsEnum RpsChosen
        {
            get { return rpsChosen; }
            set
            {
                if (rpsChosen == value) return;

                rpsChosen = value;
                switch (rpsChosen)
                {
                    case RpsEnum.Rock:
                        CheckedRock = true;
                        break;
                    case RpsEnum.Paper:
                        CheckedPaper = true;
                        break;
                    case RpsEnum.Scissors:
                        CheckedScissors = true;
                        break;
                    case RpsEnum.Undetermined:
                    default:
                        break;
                }
                OnPropertyChanged("RpsChosen");
                OnRpsChanged(new EventArgs());
            }
        }
        private RpsEnum rpsChosen;

        public bool? CheckedRock
        {
            get { return checkedRock; }
            set
            {
                if (checkedRock == value) return;

                checkedRock = value;
                setChosen(CheckedRock, RpsEnum.Rock);
                OnPropertyChanged("CheckedRock");
            }
        }
        private bool? checkedRock = false;

        public bool? CheckedPaper
        {
            get { return checkedPaper; }
            set
            {
                if (checkedPaper == value) return;

                checkedPaper = value;
                setChosen(CheckedPaper, RpsEnum.Paper);
                OnPropertyChanged("CheckedPaper");
            }
        }
        private bool? checkedPaper = false;

        public bool? CheckedScissors
        {
            get { return checkedScissors; }
            set
            {
                if (checkedScissors == value) return;

                checkedScissors = value;
                setChosen(CheckedScissors, RpsEnum.Scissors);
                OnPropertyChanged("CheckedScissors");
            }
        }
        private bool? checkedScissors = false;

        public RpsChooserViewModel()
        {
        }

        public event EventHandler RpsChanged;
        protected virtual void OnRpsChanged(EventArgs e)
        {
            if (RpsChanged != null)
            {
                RpsChanged(this, e);
            }
        }

        private void setChosen(bool? state, RpsEnum choice)
        {
            if (state.HasValue && state.Value == true)
            {
                switch (choice)
                {
                    case RpsEnum.Rock:
                        CheckedPaper = CheckedScissors = false;
                        break;
                    case RpsEnum.Paper:
                        CheckedRock = CheckedScissors = false;
                        break;
                    case RpsEnum.Scissors:
                        CheckedPaper = CheckedRock = false;
                        break;
                    case RpsEnum.Undetermined:
                    default:
                        break;
                }
                RpsChosen = choice;
            }

            //This assumes that all values are equal only when all values are false
            else if (CheckedRock == CheckedPaper && CheckedPaper == CheckedScissors)
            {
                RpsChosen = RpsEnum.Undetermined;
            }
        }
    }
}