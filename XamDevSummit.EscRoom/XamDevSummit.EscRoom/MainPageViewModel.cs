using Plugin.BluetoothLE;
using Prism.Commands;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Reactive.Threading.Tasks;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using XamDevSummit.EscapeRoom;

namespace XamDevSummit.EscRoom
{
    public class MainPageViewModel : ViewModel
    {
        public ICommand ScanCommand { get; set; }

        public MainPageViewModel()
        {
            Console.WriteLine("initialized");
            ScanCommand = ReactiveCommand.CreateFromTask(Scan);
        }
        IAdapter current = CrossBleAdapter.Current;
        private async Task Scan()
        {
            Console.WriteLine("scan pressed");
            var ad = await current.Scan();
            Console.WriteLine($"Name: {ad.AdvertisementData?.LocalName}");
        }
    }
}
