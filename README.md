# CutView
a diagonal view for xamarin forms based on NControl


## Setup
* Available on NuGet: [CutView](https://www.nuget.org/packages/CutView/) 
* Add nuget package to your Xamarin.Forms .netStandard project and to your platform-specific projects (iOS and Android)
* Initialize the NControl renderer on your platforms 

```cs
    NControl.Droid.NControlViewRenderer.Init();
     NControl.iOS.NControlViewRenderer.Init();
```

## Samples
The sample you can find here 
https://github.com/Herocod3r/CutView/blob/master/Test/App/App/MainPage.xaml


```xml

xmlns:ctrl="clr-namespace:Plugin;assembly=CutView"

   <ctrl:CutView Inset="20" FillColor="SkyBlue" />
```
*The inset idicates the percentage of cut to the view


Check source code for more info

