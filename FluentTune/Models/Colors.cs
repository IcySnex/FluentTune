using CommunityToolkit.Mvvm.ComponentModel;

namespace FluentTune.Models;

public class Colors(
    ColorsAccent accent,
    ColorsBackground background,
    ColorsStroke stroke,
    ColorsForeground foreground)
{
    public static void Override(
        Colors target,
        Colors source,
        bool ignoreAccent = false)
    {
        if (!ignoreAccent)
        {
            target.Accent.Primary = source.Accent.Primary;
            target.Accent.Light1 = source.Accent.Light1;
            target.Accent.Light2 = source.Accent.Light2;
            target.Accent.Light3 = source.Accent.Light3;
            target.Accent.Light4 = source.Accent.Light4;
            target.Accent.Dark1 = source.Accent.Dark1;
            target.Accent.Dark2 = source.Accent.Dark2;
            target.Accent.Dark3 = source.Accent.Dark3;
            target.Accent.Dark4 = source.Accent.Dark4;
        }

        target.Background.Window = source.Background.Window;
        target.Background.Popup = source.Background.Popup;
        target.Background.Control = source.Background.Control;
        target.Background.ControlLow = source.Background.ControlLow;
        target.Background.ControlMedium = source.Background.ControlMedium;
        target.Background.ControlHigh = source.Background.ControlHigh;
        target.Background.StatusNeutral = source.Background.StatusNeutral;
        target.Background.StatusSuccess = source.Background.StatusSuccess;
        target.Background.StatusCaution = source.Background.StatusCaution;
        target.Background.StatusCritical = source.Background.StatusCritical;

        target.Stroke.Popup = source.Stroke.Popup;
        target.Stroke.Control = source.Stroke.Control;
        target.Stroke.ControlLow = source.Stroke.ControlLow;
        target.Stroke.ControlMedium = source.Stroke.ControlMedium;
        target.Stroke.ControlHigh = source.Stroke.ControlHigh;

        target.Foreground.Primary = source.Foreground.Primary;
        target.Foreground.Secondary = source.Foreground.Secondary;
        target.Foreground.Tertiary = source.Foreground.Tertiary;
        target.Foreground.Quaternary = source.Foreground.Quaternary;
        target.Foreground.OnAccentPrimary = source.Foreground.OnAccentPrimary;
        target.Foreground.OnAccentSecondary = source.Foreground.OnAccentSecondary;
        target.Foreground.OnAccentTertiary = source.Foreground.OnAccentTertiary;
        target.Foreground.OnAccentQuaternary = source.Foreground.OnAccentQuaternary;
        target.Foreground.StatusNeutral = source.Foreground.StatusNeutral;
        target.Foreground.StatusSuccess = source.Foreground.StatusSuccess;
        target.Foreground.StatusCaution = source.Foreground.StatusCaution;
        target.Foreground.StatusCritical = source.Foreground.StatusCritical;
    }



    public static Colors Dark => new(
        accent: new(
            primary: "#FFFF5360",
            light1: "#FFFD8A91",
            light2: "#FFFC979E",
            light3: "#FFFFA3A9",
            light4: "#FFffB8BC",
            dark1: "#FFE66B71",
            dark2: "#FFCC5E64",
            dark3: "#FFB35057",
            dark4: "#FF872D35"),
        background: new(
            window: "#00000000",
            popup: "#ff2c2c2c",
            control: "#0FFFFFFF",
            controlLow: "#08FFFFFF",
            controlMedium: "#15FFFFFF",
            controlHigh: "#24FFFFFF",
            statusNeutral: "#ff2e2e2e",
            statusSuccess: "#ff393d1b",
            statusCaution: "#ff433519",
            statusCritical: "#ff442726"),
        stroke: new(
            popup: "#22000000",
            control: "#12FFFFFF",
            controlLow: "#17FFFFFF",
            controlMedium: "#23FFFFFF",
            controlHigh: "#28FFFFFF"),
        foreground: new(
            primary: "#FFFFFFFF",
            secondary: "#C5FFFFFF",
            tertiary: "#87FFFFFF",
            quaternary: "#5DFFFFFF",
            onAccentPrimary: "#FF000000",
            onAccentSecondary: "#80000000",
            onAccentTertiary: "#83FFFFFF",
            onAccentQuaternary: "#87FFFFFF",
            statusNeutral: "#ff9d9d9d",
            statusSuccess: "#ff6ccb5f",
            statusCaution: "#fffce100",
            statusCritical: "#ffff99a4"));


    public Colors() : this(
        accent: Dark.Accent,
        background: Dark.Background,
        stroke: Dark.Stroke,
        foreground: Dark.Foreground)
    { }


    public ColorsAccent Accent { get; set; } = accent;

    public ColorsBackground Background { get; set; } = background;

    public ColorsStroke Stroke { get; set; } = stroke;

    public ColorsForeground Foreground { get; set; } = foreground;
}


public partial class ColorsAccent(
    string primary,
    string light1,
    string light2,
    string light3,
    string light4,
    string dark1,
    string dark2,
    string dark3,
    string dark4) : ObservableObject
{
    [ObservableProperty]
    string primary = primary;


    [ObservableProperty]
    string light1 = light1;

    [ObservableProperty]
    string light2 = light2;

    [ObservableProperty]
    string light3 = light3;

    [ObservableProperty]
    string light4 = light4;


    [ObservableProperty]
    string dark1 = dark1;

    [ObservableProperty]
    string dark2 = dark2;

    [ObservableProperty]
    string dark3 = dark3;

    [ObservableProperty]
    string dark4 = dark4;
}

public partial class ColorsBackground(
    string window,
    string popup,
    string control,
    string controlLow,
    string controlMedium,
    string controlHigh,
    string statusNeutral,
    string statusSuccess,
    string statusCaution,
    string statusCritical) : ObservableObject
{
    [ObservableProperty]
    string window = window;
    

    [ObservableProperty]
    string popup = popup;


    [ObservableProperty]
    string control = control;

    [ObservableProperty]
    string controlLow = controlLow;

    [ObservableProperty]
    string controlMedium = controlMedium;

    [ObservableProperty]
    string controlHigh = controlHigh;


    [ObservableProperty]
    string statusNeutral = statusNeutral;

    [ObservableProperty]
    string statusSuccess = statusSuccess;

    [ObservableProperty]
    string statusCaution = statusCaution;

    [ObservableProperty]
    string statusCritical = statusCritical;
}

public partial class ColorsStroke(
    string popup,
    string control,
    string controlLow,
    string controlMedium,
    string controlHigh) : ObservableObject
{
    [ObservableProperty]
    string popup = popup;


    [ObservableProperty]
    string control = control;

    [ObservableProperty]
    string controlLow = controlLow;

    [ObservableProperty]
    string controlMedium = controlMedium;

    [ObservableProperty]
    string controlHigh = controlHigh;
}

public partial class ColorsForeground(
    string primary,
    string secondary,
    string tertiary,
    string quaternary,
    string onAccentPrimary,
    string onAccentSecondary,
    string onAccentTertiary,
    string onAccentQuaternary,
    string statusNeutral,
    string statusSuccess,
    string statusCaution,
    string statusCritical) : ObservableObject
{
    [ObservableProperty]
    string primary = primary;

    [ObservableProperty]
    string secondary = secondary;

    [ObservableProperty]
    string tertiary = tertiary;

    [ObservableProperty]
    string quaternary = quaternary;


    [ObservableProperty]
    string onAccentPrimary = onAccentPrimary;

    [ObservableProperty]
    string onAccentSecondary = onAccentSecondary;

    [ObservableProperty]
    string onAccentTertiary = onAccentTertiary;

    [ObservableProperty]
    string onAccentQuaternary = onAccentQuaternary;


    [ObservableProperty]
    string statusNeutral = statusNeutral;

    [ObservableProperty]
    string statusSuccess = statusSuccess;

    [ObservableProperty]
    string statusCaution = statusCaution;

    [ObservableProperty]
    string statusCritical = statusCritical;
}