﻿# xyLOGIX.DarkMessageBox

A drop-in dark-themed replacement for `System.Windows.Forms.MessageBox` that supports per-dialog theming, auto-close timers, and full Win10/11 title-bar dark-mode via [DarkNet](https://www.nuget.org/packages/DarkNet/).

## Dark-Themed Message Box Library

The idea for this project came about when I was writing an app for a client that was required to have a Dark theme.

Then, a requirement came in to write code to use a `System.Windows.Forms.MessageBox` to prompt the user whether the user is sure they wanted to delete an item from a list.

I tested it, and the dark mode application looked great, but then the system-provided message box showed up in a Light theme against the Dark-themed background, and hurt my eyes.

I thought, "I can't have that!"

After some Googling, it was not apparent that there are many resources out there for Dark-theming the system-provided message boxes; it was more like, "roll your own."

The requirement was to roll my own Dark-theme message box that looked and felt as much like the system-provided message boxes as possible, but with a Dark theme.

Therefore, it occurred to me to whip up this NuGet package.

And then I also threw in some goodies as well!

The results are being distributed as this publicly-available NuGet package because I want to share my findings with the world.  I hope you find it useful!

Believe it or not, every so often, a dark-themed WinForm or WPF app will be being written...and when it is, I hope this NuGet package proves useful.

[![NuGet](https://img.shields.io/nuget/v/xyLOGIX.DarkMessageBox.svg?logo=nuget&style=flat)](https://www.nuget.org/packages/xyLOGIX.DarkMessageBox/1.0.0)
[![License: MIT](https://img.shields.io/badge/license-MIT-blue.svg)](LICENSE)

As stated above, this NuGet package provides a fully customizable dark-themed replacement for `System.Windows.Forms.MessageBox`,  
built for C# 7.3, .NET Framework 4.8, and Windows Forms 2.0 applications, and which behaves as closely as possible to the original `System.Windows.Forms.MessageBox` class, otherwise.

Supports runtime theming, customizable colors and fonts, dynamic titlebar styling, default button highlighting, and full visual consistency with native Windows message boxes.

---

## 📦 Install via NuGet

Install **xyLOGIX.DarkMessageBox** via the NuGet Package Manager:

```
Install-Package xyLOGIX.DarkMessageBox
```

Or via .NET CLI:

```
nuget install xyLOGIX.DarkMessageBox
```

(Totally optional.) If you like this NuGet package, please use the tip jar to show your support:

[![Donate](https://raw.githubusercontent.com/astrohart/xyLOGIX.DarkMessageBox/refs/heads/master/images/tip-jar.png)](https://buy.stripe.com/5kA4iz8j85lX9Pi6oo)

This package is made available under the MIT license completely free of charge...but we value any and all tips, no matter how small.  Thank you for your support!

---

## ✨ Features

- Professional dark-themed message boxes.
- Fully customizable visual themes.
- Dynamic theme switching at runtime.
- Default button highlighting (border or background color).
- Supports dark/light titlebars.
- Auto-sizing for very short and very long messages.
- Fully supports Windows Forms 2.0 (`System.Windows.Forms`).
- Standard `Ctrl+C` clipboard behavior (pressing `Ctrl+C` while the message box is displayed copies a text version of it to the Clipboard).
- Designed for production-grade applications.


## Screenshots

You're probably dying to know what the default Dark-themed message boxes provided by this library look like.

Here's what a simple message box looks like:

![Fig01](https://raw.githubusercontent.com/astrohart/xyLOGIX.DarkMessageBox/refs/heads/master/images/fig01.png)

**Figure 1.** Simple **OK** message box.

And here's what a message box with a question-mark icon, and **OK** and **Cancel** buttons looks like:

![Fig02](https://raw.githubusercontent.com/astrohart/xyLOGIX.DarkMessageBox/refs/heads/master/images/fig02.png)

**Figure 2.** Message box with **OK** and **Cancel** buttons and a question-mark icon.

Now, let's see what a message box that has the warning/exclamation-mark icon, and **Yes** and **No** buttons looks like:

![Fig03](https://raw.githubusercontent.com/astrohart/xyLOGIX.DarkMessageBox/refs/heads/master/images/fig03.png)

**Figure 3.** Message box with **Yes** and **No** buttons and an exclamation-mark icon.

Now, let's see what we get when we specifiy `MessageBoxIcon.Question` and `MessageBoxButtons.YesNoCancel`:

![Fig04](https://raw.githubusercontent.com/astrohart/xyLOGIX.DarkMessageBox/refs/heads/master/images/fig04.png)

**Figure 4.** Message box with **Yes**, **No**, and **Cancel** buttons and a question-mark icon.

Let's see what we get when we specify `MessageBoxIcon.Stop` and `MessageBoxButtons.RetryCancel`:

![Fig05](https://raw.githubusercontent.com/astrohart/xyLOGIX.DarkMessageBox/refs/heads/master/images/fig05.png)

**Figure 5.** Message box with **Retry** and **Cancel** buttons and a stop-sign icon.

Finally, I bet you're really excited to see what a message box with a `MessageBoxIcons.Stop` icon and **Abort**, **Retry**, and **Ignore** buttons looks like:

![Fig06](https://raw.githubusercontent.com/astrohart/xyLOGIX.DarkMessageBox/refs/heads/master/images/fig06.png)

**Figure 6.** Message box with **Abort**, **Retry**, and **Ignore** buttons and a stop-sign icon.

Here's a message box with an information icon and just an **OK** button, but with wider text:

![Fig07](https://raw.githubusercontent.com/astrohart/xyLOGIX.DarkMessageBox/refs/heads/master/images/fig07.png)

**Figure 7.** Message box with **OK** button and an information icon with wider, longer text.

See how it adjusts its size, just like the message box(es) that come with Windows do?

You're probably wondering what occurs if you specify a message that has very short text.  Well, I'll show you:

![Fig08](https://raw.githubusercontent.com/astrohart/xyLOGIX.DarkMessageBox/refs/heads/master/images/fig08.png)

**Figure 8.** Message box with **OK** button and an information icon with very short text.

One nice feature of the default message boxes that ship with all copies of Microsoft Windows is the fact that they will also widen themselves if the caption is very very long, even if the message body text is not.  Our message box does this, too.  Here's an example of a message box with a very long caption, but short body text:

![Fig09](https://raw.githubusercontent.com/astrohart/xyLOGIX.DarkMessageBox/refs/heads/master/images/fig09.png)

**Figure 9.** Message box with **OK** button and an information icon with very long caption text.

There is a cap on the width of the message box, though.  If the message body text is too long, the message box will be restricted in how wide it can grow.

![Fig10](https://raw.githubusercontent.com/astrohart/xyLOGIX.DarkMessageBox/refs/heads/master/images/fig10.png)

**Figure 10.** Message box with **Yes**, **No**, and **Cancel** buttons, a question-mark icon, and an information icon with very long body text.

You can override this cap by setting the `DarkMessageBoxMetrics.MaximumFormWidth` property.

The message box, just like the version that ships with Windows, also will make itself taller if you have long text in the body of the message box.  Here's an example of a message box with a very long body text, but short caption text:

![Fig11](https://raw.githubusercontent.com/astrohart/xyLOGIX.DarkMessageBox/refs/heads/master/images/fig11.png)

**Figure 11.** Message box with **OK** and **Cancel** buttons and an information icon with very long body text that makes it size itself taller to accommodate.

This is all included out-of-the-box with this code.  My aim was to make a message box that looks and feels exactly the same as those that ship with Windows, but with a dark theme.

---

## 🚀 Quick Usage Example

You can use `DarkMessageBox.Show` to display a message box.  It has the same signature as `System.Windows.Forms.MessageBox.Show`, so you can use it in place of `System.Windows.Forms.MessageBox.Show` without any changes to your code.

```csharp
using xyLOGIX.DarkMessageBox;

// Simple OK dialog
DarkMessageBox.Show("Operation completed successfully.", "Success");

// Yes/No dialog
var result = DarkMessageBox.Show(
    "Would you like to save changes?",
    "Confirm Save",
    MessageBoxButtons.YesNo,
    MessageBoxIcon.Question,
    MessageBoxDefaultButton.Button1
);

if (result == DialogResult.Yes)
{
    // Save logic here
}
```
**Listing 1.** Simple usage example of the `DarkMessageBox` class.

You can even optionally pass in a reference to any class that implements `IWin32Window`, in the first parameter, to designate the parent window of the message box:

```csharp
using xyLOGIX.DarkMessageBox;

/*...*/

public class MainWindow : Form
{
    public void PromptUser()
    {
        // Simple OK dialog
        DarkMessageBox.Show(this, "Operation completed successfully.", "Success");

        // Yes/No dialog
        var result = DarkMessageBox.Show(
            this,
            "Would you like to save changes?",
            "Confirm Save",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question,
            MessageBoxDefaultButton.Button1
        );

        if (result == DialogResult.Yes)
        {
            // Save logic here
        }
    }
}
```
**Listing 2.** Usage example of the `DarkMessageBox` class with a parent window.

---

**NOTE:** This new message box also changes the style of its titlebar to match the current Windows desktop theme -- a black title bar is used if the theme is `Dark` operating-system wide; or a white title bar is used if the theme is `Light` operating-system wide.  This is done to ensure that the message box is visually consistent with the rest of the Windows UI.  This corrects a deficiency in the original `System.Windows.Forms.MessageBox` class, which does not change the title bar color to match the current Windows theme.

---

## 🎨 Theme-switching Example


You know, the standard Win32 `MessageBox` message boxes really do not leave a whole lot of room for skinning and customizing their look, feel, behavior, and actions.  Well, that ends now -- with this NuGet package, you can skin the ever-living _snot_ out of your message boxes.  You can:

* Set it to automatically close after a certain number of milliseconds; 
* Override the message box body icon that is displayed next to the body with your own custom icon (or display none at all);
* Give the message box _window_ its own corresponding icon and even make it appear in the Taskbar.  
    * This can be useful, say, when you are displaying the message box during app startup but before the main application window has appeared.
    * This allows users to find your message box easily by clicking its Taskbar icon without having to resort to `ALT+TAB`;
* Customize button text, message content text, titlebar, background, and footer colors; and
* Set the `DarkMessageBoxMetrics.TitleBarIsLight` property to make the titlebar be light or dark;

... and more!

---


**NOTE:** Support is currently not implemented for changing the _shape_ of the message boxes, though.

---

Customization is best done by using `Theme`s.  These are concrete classes that implement the `IDarkMessageBoxTheme` interface.  You can create your own themes by implementing this interface, or you can use the built-in themes.

It is recommended to always create your concrete theme classes as Singletons. 

Example theme classes are shown: 

* `ProfessionalDarkTheme` - sets a professional dark theme style.
* `BartSimpsonTheme` - sets a novelty theme with Bart Simpson colors and button text.
* `CowabungaTheme` - sets a novelty theme with Teenage Mutant Ninja Turtles* colors and button texts that correspond to what Michaelangelo or Raphael might say.

For demonstration purposes, `BartSimpsonTheme`, `CowabungaTheme`, and `ProfessionalDarkTheme` classes are included with this codebase that you can use out-of-the-box.

### Bart Simpson `*` theme

For example, here is what a message box displayed using the `BartSimpsonTheme` looks like:

![Fig12](https://raw.githubusercontent.com/astrohart/xyLOGIX.DarkMessageBox/refs/heads/master/images/fig12.png)

**Figure 12.** Bart Simpson`*`-themed message box.

The example message box shown in **Figure 12** is displayed using the `BartSimpsonTheme` class, and isn't it something that Bart would totally say, instead of "File not found"?  

The `BartSimpsonTheme` class is included in this NuGet package, in the `xyLOGIX.DarkMessageBox.Themes` namespace.  You can refer to it in your code via the static `BartSimpsonTheme.Instance` property.

Furthermore, the `BartSimpsonTheme` class can be inherited, and its `Apply` method can be overridden to customize the look and feel of the message box even further.  This is useful if you want to create your own custom theme that is based on the `BartSimpsonTheme` class.

Just remember, if you do override the `BartSimpsonTheme.Apply` method, to call the base-class version first.

### Cowabunga theme

Here's what a message box, displaying using the colors and styles of the 1987 Teenage Mutant Ninja Turtles`**` cartoon, might look like, with a fun little 'Michelangelo' icon:

![Fig13](https://raw.githubusercontent.com/astrohart/xyLOGIX.DarkMessageBox/refs/heads/master/images/fig13.png)

**Figure 13.** Teenage Mutant Ninja Turtles`**`-themed message box.

And, FYI, the phrase **Let's Quit While We're Ahead**, which is used in place of **Cancel** is probably more like something that the 1987 version of Raphael might have said; but, I couldn't find a good icon for him.  So, I went with Michelangelo.  But Michelangelo can have all the fun!  The message box is still themed to look like the TMNT cartoon, though.

This theme is included in this package as the `CowabungaTheme` class in the `xyLOGIX.DarkMessageBox.Themes` namespace.  You can refer to it in your code via the static `CowabungaTheme.Instance` property.

Furthermore, the `CowabungaTheme` class can be inherited, and its `Apply` method can be overridden to customize the look and feel of the message box even further.  This is useful if you want to create your own custom theme that is based on the `CowabungaTheme` class.

Just remember, if you do override the `CowabungaTheme.Apply` method, to call the base-class version first.

Cowabunga!

Now, let's see what the `ProfessionalDarkTheme` looks like.

### Professional dark theme

And, if we revert to the `ProfessionalDarkTheme`, the message box looks like this:

![Fig14](https://raw.githubusercontent.com/astrohart/xyLOGIX.DarkMessageBox/refs/heads/master/images/fig14.png)

**Figure 14.** Professional dark-themed message box.

The `ProfessionalDarkTheme` is the default.

The code automatically validates the settings of all themes so that we don't use things such as zero widths for buttons or the _x_-coordinate of the right-hand side of a button being less than the _x_-coordinate of the left-hand side of the button.  

This is done to ensure that the message box is always displayed correctly, regardless of the theme you choose.  

If a particular theme has invalid value(s) for its property(ies), it will simply be suppressed, and the `ProfessionalDarkTheme` will be substituted instead.  

Messages will be emitted to the **Debug** output window in Visual Studio telling you what setting is not correct, however.

This theme is included in this package as the `ProfessionalDarkTheme` class in the `xyLOGIX.DarkMessageBox.Themes` namespace.  You can refer to it in your code via the static `ProfessionalDarkTheme.Instance` property.

Furthermore, the `ProfessionalDarkTheme` class can be inherited, and its `Apply` method can be overridden to customize the look and feel of the message box even further.  This is useful if you want to create your own custom theme that is based on the `ProfessionalDarkTheme` class.

Just remember, if you do override the `ProfessionalDarkTheme.Apply` method, to call the base-class version first.

### System color theme

For completeness' sake, I also included a `SystemColorTheme` class that uses the system colors for the message box.  This is useful if you want to use the same colors as the current Windows theme.  This theme is designed to make the `DarkMessageBox` look, feel, and behave as close to those of the original `System.Windows.Forms.MessageBox` as possible.

A `SystemColorTheme` message box will look like this:

![Fig15](https://raw.githubusercontent.com/astrohart/xyLOGIX.DarkMessageBox/refs/heads/master/images/fig15.png)

**Figure 15.** System color-themed message box.

The following unit test demonstrates how to use the `SystemColorTheme` class:

```csharp
    /// <summary>
    /// Displays a <see cref="T:xyLOGIX.DarkMessageBox.DarkMessageBox" /> using the
    /// System Color theme.
    /// </summary>
    /// <remarks>
    /// This illustrates causing the appearance of the message box to exactly
    /// match that of the system-provided message boxes using the
    /// <see cref="T:xyLOGIX.DarkMessageBox.Themes.SystemColorTheme" /> class.
    /// <para />
    /// This is provided to illustrate how to make a
    /// <see cref="T:xyLOGIX.DarkMessageBox.DarkMessageBox" /> look like the default.
    /// </remarks>
    [Test]
    public void Show_DarkMessageBox_ThemedAsSystem()
    {
        // Apply the system color theme
        DarkMessageBoxThemeManager.ApplyTheme(SystemColorTheme.Instance);

        // Show a message box with the system theme
        DarkMessageBox.Show(
            @"The file 'C:\foo.txt' has been modified.\n\nDid you want to save your changes?", "System Theme Test",
            MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation,
            MessageBoxDefaultButton.Button2
        );
    }
```
**Listing 3.** Unit test that demonstrates how to use the `SystemColorTheme` class.

Why would anyone use the `SystemColorTheme` class when the whole point of this NuGet package is to make dark-themed message boxes?  

Well, the `SystemColorTheme` class is useful for testing purposes, and for those who want to use the same colors as the current Windows theme.  

It is also useful for those who want to use the same colors as the original `System.Windows.Forms.MessageBox` class without having to change every point in your code that calls `DarkMessageBox` by hand.

The `SystemColorTheme` class is also useful if your application implements a toggle between Light/Dark themes, you can simply also toggle between the `SystemColorTheme` and `ProfessionalDarkTheme`  once you've toggled the `Light` or `Dark` mode(s) in your application, respectively.  Perhaps you might say:

```csharp
using System;
using System.Drawing;
using System.Windows.Forms;
using xyLOGIX.DarkMessageBox;

namespace MyApp
{
    public class MainWindow
    {
        // Manages whether the currently open file has been modified.
        public IsDirty { get; set; }

        // perhaps this is a property of your main window class
        // that stores the fully-qualified pathname of the currently-
        // open file.
        public string CurrentFileName { get; set; }

        /* ... property that indicates whether the app is in Light or Dark mode ... */
        public bool IsDarkMode { get; set; }

        // perhaps this method is called with the click of a menu command
        // or toolbar button
        public void ToggleLightOrDarkMode()
        {
            // Toggle the theme
            IsDarkMode = !IsDarkMode;

            // Apply the appropriate message box theme
            DarkMessageBoxThemeManager.ApplyTheme(
                IsDarkMode
                    ? ProfessionalDarkTheme.Instance
                    : SystemColorTheme.Instance
            );
        }

        /* or, you could do it on a case-by-case basis */

        public void PromptUserToSave()
        {
            // If the current file isn't modified, then there 
            // isn't a need to prompt the user to save their 
            // changes.
            if (!IsDirty) return;
    
            // Apply the appropriate theme
            DarkMessageBoxThemeManager.ApplyTheme(
                 IsDarkMode ? ProfessionalDarkTheme.Instance : SystemColorTheme.Instance
            );

            // Show a message box with the system theme
            if (DialogResult.No.Equals(DarkMessageBox.Show(
                  this,
                  $@"The file '{CurrentFileName}' has been modified.\n\nDid you want to save your changes?", Application.ProductName,
                  MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation,
                  MessageBoxDefaultButton.Button2
            )) return;

            /* ... */
            /* Save the file */
            /* ... */
        }
    }
}

```
**Listing 4.** Example of how to toggle between the `ProfessionalDarkTheme` and `SystemColorTheme` classes.

One should note that it really is only necessary to call `DarkMessageBoxThemeManager.ApplyTheme` once, at the start of your application -- or, when you toggle between `Light` and `Dark` modes -- to set the theme for all message boxes in your application.  However, you can call it as many times as you like, and it will apply the theme you specify.  This may be handy if there are a few isolated message boxes that you want to have a different theme than the rest of your application.

This theme is included in this package as the `SystemColorTheme` class in the `xyLOGIX.DarkMessageBox.Themes` namespace.  You can refer to it in your code via the static `SystemColorTheme.Instance` property.

Furthermore, the `SystemColorTheme` class can be inherited, and its `Apply` method can be overridden to customize the look and feel of the message box even further.  This is useful if you want to create your own custom theme that is based on the `SystemColorTheme` class.

Just remember, if you do override the `SystemColorTheme.Apply` method, to call the base-class version first.


---
**NOTE:** To ensure elements from previous themes do not carry over to the next, each implementation of the `IDarkMessageBoxTheme.Apply` method MUST start out by calling the `DarkMessageBoxMetrics.Reset` method PRIOR to then customizing the look and feel of the message box.  

Calling `DarkMessageBoxMetrics.Reset` resets the dialog style, colors, look, and feel to the default, professional dark theme. 

Overrides of an `Apply` method from a derived class inheriting one of the theme(s) that ship with this NuGet package must call the base-class version first; it is not necessary to call the `DarkMessageBoxMetrics.Reset` method in this case, as the base-class version of `Apply` will do that for you.

---

```csharp
// Apply a Bart Simpson novelty theme
DarkMessageBoxThemeManager.ApplyTheme(BartSimpsonTheme.Instance);

// Revert to default professional theme later
DarkMessageBoxThemeManager.ApplyTheme(ProfessionalDarkTheme.Instance);
```

The `DarkMessageBoxThemeManager.ApplyTheme` method must always be called prior to `DarkMessageBox.Show` to use the theme you want.

In case you set a theme, display a message box, and then forget to set it back, the message box will reset the theme for you, to the `ProfessionalDarkTheme`, when it is closed.  You can suppress this behavior by setting the `DarkMessageBoxMetrics.SuppressAutoReset` property to `true`.  Setting the `DarkMessageBoxMetrics.SuppressAutoReset` property to `true` causes all the message boxes in your application, from that moment on, to display using the theme you set.

The various themes set the property(ies) of the `DarkMessageBoxMetrics` static class.  

To force the titlebar of the message box to be Light-themed (i.e., white), set `DarkMessageBoxMetrics.TitleBarIsLight` to `true`.  It's `false` by default, which means to display a black titlebar.

---

## 🤝 Contributing

Contributions, bug reports, and feature suggestions are welcome!

Please open a [GitHub Issue](https://github.com/astrohart/xyLOGIX.DarkMessageBox/issues)  
or submit a Pull Request.  No promises or guarantees are made as to whether issues will be addressed, nor whether PRs will be accepted.

You may fork this repo freely.

---

## 📜 License

This project is licensed under the [MIT License](LICENSE).

Copyright © 2025 by Dr. Brian Curtis Hart xyLOGIX, LLC.  
All rights reserved.  This project is hereby released and distributed under the terms of the MIT license.

---

## Lawyer-friendly fine print

`*` The Simpsons® and Bart Simpson® are trademarks of Twentieth Century Fox Film Corporation. They are used in this article solely for example and education purposes only, and for commentary, and are not affiliated with or endorsed by the author, nor is this work affiliated with, nor is endorsed by, Twentieth Century Fox Film Corporation. © 2024 Twentieth Century Fox Film Corporation. All rights reserved.  Fair use is asserted.

`**` Teenage Mutant Ninja Turtles™ and all related titles, logos, and characters are trademarks of Viacom International Inc. © Viacom International Inc. All rights reserved.  This article is for informational and commentary purposes only. No affiliation with or endorsement by Viacom International Inc. or Nickelodeon is implied.  Fair use is asserted.

**Disclaimer.** All product names, logos, brands, characters, and registered or unregistered trademarks referenced in this publication remain the property of their respective owners. Use of these marks is for identification, commentary, or illustrative purposes only and does not imply any sponsorship, endorsement, or affiliation with the rightful trademark holders.

The information provided herein is for general informational and educational purposes. While reasonable efforts have been made to ensure accuracy, the author(s) make no warranties, express or implied, regarding completeness, reliability, or suitability for any purpose. Any reliance you place on such information is strictly at your own risk.

All original text, code samples, and artwork contained in this document are Copyright © 2025 by Dr. Brian Curtis Hart and xyLOGIX, LLC.  Distributed under the MIT license.  Unauthorized reproduction or distribution, in whole or in part, is prohibited except as permitted under applicable law or the MIT license terms.

References to third-party content are presented under fair-use principles for the purposes of review, criticism, or scholarship.

**No legal advice.** Nothing in this document should be construed as legal, financial, or professional advice. Consult qualified professionals for guidance specific to your situation.