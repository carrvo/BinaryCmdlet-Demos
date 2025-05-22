# BinaryCmdlet-Demos

This is a collection of demonstrations and experiments that showcase what is feasible with [binary cmdlets](https://learn.microsoft.com/en-us/powershell/scripting/developer/cmdlet/how-to-write-a-simple-cmdlet).

Of particular note:
- [Generic Cmdlets](./GenericCmdlets/)
- [Multiple Backends](./TestMultipleBackends/) for dependency management
- [Testing Methods](./TestPowerShell/)

## [Generic Cmdlets](./GenericCmdlets/)

This showcases how binary cmdlets interact with generics.

### Input / Output

See [GetGenericListCommand.cs](./GenericCmdlets/TypeParameters/GetGenericListCommand.cs).

1. A input type can be used to construct a generic instance (in this case a `List<>`).
    - This input must be of type `Type`.
	- This can only be accomplished using reflection.
1. Generic instances can be used as output as normal.

### Cmdlet Class

See [GetFromCmdletCommand.cs](./GenericCmdlets/GenericCmdlets/GetFromCmdletCommand.cs).

1. Generics cannot be used as cmdlets directly.
1. However, generics *can* be used in the inheritance tree (including adding parameters, et cetera). **Note** that this still entails a unique cmdlet name for the concrete class.

## [Multiple Backends](./TestMultipleBackends/)

This showcases how you can deploy and swap backends (or any dependency) *without modification to, or redeployment of, your application*.
This is acheived by **not** having the backend as a direct compile-time dependency.
Instead, the different backends must meet an interface specification that the application depends on.
After that, they can be swapped out and configured by modifying a simple text script.
***I believe this to be a better dependency management solution.***

See [the (oversimplified) database application](./TestMultipleBackends/TestMultipleBackends/InvokeMyAppCommand.cs);
its [interface specification](./TestMultipleBackends/TestMultipleBackends/ISQLProvider.cs);
the two database backends: [SQL Server](./TestMultipleBackends/SQLServerBackend/SQLServerProvider.cs)
and [SQLite](./TestMultipleBackends/SQLiteBackend/SQLiteProvider.cs).
```powershell
Connect-SQLServer -Server myserver -Instance myinstance -Database mydatabase -UserID admin -Password pass | Invoke-MyApp
Connect-SQLite -Path C:\mydb.sqlite3 | Invoke-MyApp
```

Extensions:
- Either an explicit adapter or an implicit adapter, such as through the [AutoAdapter](github.com/carrvo/AutoAdapter) project, can be used to further separate dependencies by not requiring either side of the interface to know about the other.
- Since the backend is held as an object, this should be able to swap out backends **during run-time** using appropriate concurrency mechanisms. This requires *extreme caution* as, with the case of databases, you may not be able to guarentee that the tables were created on the new database or that any data has been copied!
- Potentially handing over multiple backends.

## [Testing Methods](./TestPowerShell/)

This showcases both how binary cmdlets can be [used natively](./TestPowerShell/TestCmdlet2/Program.cs) (no PowerShell involvement) and the various methods for testing.

- [Natively with XUnit](./TestPowerShell/XUnitTest/UsingCmdletDirectly.cs)
- [Invoking PowerShell from C#](./TestPowerShell/XUnitTest/UsingCmdletIndirectly.cs)
- Pester

## [GUI Test](./PSGUITest/)

This showcases how PowerShell can be used to construct, display, and interact (in flight) with a Windows Forms object.
***I believe this to be a much better pattern*** than the increasingly popular [constructing a GUI within PowerShell](https://devblogs.microsoft.com/scripting/create-a-simple-graphical-interface-for-a-powershell-script/) pattern (and endorsed by the [templates](https://marketplace.visualstudio.com/items?itemName=AdamRDriscoll.PowerShellToolsVS2022)).

1. Create a [Windows Form](./PSGUITest/PowerShellFormCmdlet/SquareForm.cs)
1. *Optionally* (and more secure) create a [config object](./PSGUITest/PowerShellFormCmdlet/Config.cs) to act as a buffer between your form and PowerShell to limit what is accessible by users. **Note** that all public members will be accessible, regardless of casting to an interface!
1. [Display](./PSGUITest/PowerShellFormCmdlet/StartForm.cs) your form.

It is also useful to allow PowerShell to [close your form](./PSGUITest/PowerShellFormCmdlet/StopForm.cs).

Please see [examples for interacting with the form from PowerShell](./PSGUITest/PowerShellFormCmdlet/Demo.Tests.ps1).

Furthermore, this form can be utilized as a [normal GUI application](./PSGUITest/PowerShellGUI/Program.cs).

## [Coding Structure](./CodingStructureExample/)

A proposed structure for creating applications *--deprecated, there is [another project](https://github.com/carrvo/BinaryCmdletTemplates) that was developed with more experience behind it.*

Here, data objects, algorithms that use them as input, and components that use the algorithms are split into three projects.
Splitting them allows for the component to utilize the algorithm without it being listed as a compile-time dependency.
See the [AutoAdapter](github.com/carrvo/AutoAdapter) project for how this is possible.

### Using the Algorithm

Import the data objects and algorithms
```powershell
Import-Module .\bin\Concrete.psd1
Import-Module .\bin\Algorithm.psd1

# if not importing TypeData properly then it can be done manually through
Update-TypeData -AppendPath .\bin\Algorithm.Types.ps1xml
```

They can either be used as cmdlets
```powershell
Get-DTO -Value 5 | Get-PlusOne
```

Or they can take advantage of TypeData
```powershell
$dto = Get-DTO -Value 5
$dto.PlusOne()
```

### Limitations of the Component

Unfortunately it was found that components cannot natively use the algorithm through this pattern.
See [the examples](./CodingStructureExample/Component/PowerShellAdapter.Tests.ps1) for what does and does not work.
