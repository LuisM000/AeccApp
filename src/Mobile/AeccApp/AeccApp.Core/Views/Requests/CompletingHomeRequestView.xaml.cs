﻿using AeccApp.Core.Messages;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;
using Xamarin.Forms.Xaml;

namespace AeccApp.Core.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CompletingHomeRequestView : BaseContentPage
	{

        public CompletingHomeRequestView()
		{
           
            MessagingCenter.Subscribe<GeolocatorMessages, Position>(this, string.Empty, (sender, arg) =>
              MoveCameraMap(arg));
            InitializeComponent ();
            map.InitialCameraUpdate = CameraUpdateFactory.NewPositionZoom(new Position(40.416937, -3.703523), 6d);
                 
        }

   
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<GeolocatorMessages>(this,string.Empty);
        }
        public async void MoveCameraMap(Position toPosition)
        {
            var animState = await map.AnimateCamera(CameraUpdateFactory.NewPositionZoom(
                     toPosition, 16d), TimeSpan.FromSeconds(1));

            var addressPin = new Pin() { Label = "Tu dirección", Position = toPosition };
            addressPin.IsDraggable = false;
            switch (Device.OS)
            {
                case TargetPlatform.Android:
                    // addressPin.Icon = BitmapDescriptorFactory.FromBundle($"location_pin.png");
                    break;
                case TargetPlatform.iOS:
                    addressPin.Icon = BitmapDescriptorFactory.FromBundle($"location_pin.png");
                    break;
                default:
                    addressPin.Icon = BitmapDescriptorFactory.FromBundle($"Assets/location_pin.png");
                    break;
            }

            map.Pins.Add(addressPin);


        }

        
    }
}