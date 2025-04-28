# xyLOGIX.DarkMessageBox

[![NuGet](https://img.shields.io/nuget/v/xyLOGIX.DarkMessageBox.svg?logo=nuget&style=flat)](https://www.nuget.org/packages/xyLOGIX.DarkMessageBox/)
[![License: MIT](https://img.shields.io/badge/license-MIT-blue.svg)](LICENSE)

A fully customizable dark-themed replacement for `System.Windows.Forms.MessageBox`,  
built for C# 7.3 and .NET Framework 4.8 Windows Forms applications.

Supports runtime theming, customizable colors and fonts, dynamic titlebar styling,  
default button highlighting, and full visual consistency with native Windows dialogs.

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

---

## ✨ Features

- Professional dark-themed message boxes
- Fully customizable visual themes
- Dynamic theme switching at runtime
- Default button highlighting (border or background color)
- Supports dark/light titlebars
- Auto-sizing for very short and very long messages
- Fully supports Windows Forms 2.0 (`System.Windows.Forms`)
- Standard Ctrl+C clipboard behavior
- Designed for production-grade applications

---

## 🚀 Quick Usage Example

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

---

## 🎨 Theme Switching Example

```csharp
// Apply a Bart Simpson novelty theme
DarkMessageBoxThemeManager.ApplyTheme(new BartSimpsonTheme());

// Revert to default professional theme later
DarkMessageBoxThemeManager.ApplyTheme(new DefaultDarkMessageBoxTheme());
```

---

## 🤝 Contributing

Contributions, bug reports, and feature suggestions are welcome!

Please open a [GitHub Issue](https://github.com/astrohart/xyLOGIX.DarkMessageBox/issues)  
or submit a Pull Request.

---

## 📜 License

This project is licensed under the [MIT License](LICENSE).

Copyright © 2025 by xyLOGIX, LLC.  
All rights reserved.
