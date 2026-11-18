# pack existing release build
Set-Location $PSScriptRoot
$packCmd = 'dotnet pack $Name --no-build --output ../Release --configuration Release'
$projList = 'Fonlow.ErpNext/Fonlow.ErpNext.csproj', 'Fonlow.ErpNext.Abstract/Fonlow.ErpNext.Abstract.csproj', 'Fonlow.ErpNext.CrmModels/Fonlow.ErpNext.CrmModels.csproj', 'Fonlow.ErpNext.Models/Fonlow.ErpNext.Models.csproj', 'Fonlow.ErpNextAsp/Fonlow.ErpNextAsp.csproj'
foreach($name in $projList){
    Invoke-Expression $ExecutionContext.InvokeCommand.ExpandString($packCmd)
}