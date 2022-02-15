Describe "Demo" {
	BeforeAll {
		Import-Module $PSScriptRoot\PowerShellFormCmdlet.dll
	}

	It "can change colour with a complex function" {
		$config = Start-Form
		$config.BackColor = Get-Color -RedShading 0 -GreenShading 0 -BlueShading 200
		1..255 | foreach {
			$config.BackColor = Get-Color -BaseColor $config.BackColor -RedShading $(($config.BackColor.R + 1) % 255)
			Start-Sleep -Milliseconds 10
		}
		$config | Stop-Form
	}
}
