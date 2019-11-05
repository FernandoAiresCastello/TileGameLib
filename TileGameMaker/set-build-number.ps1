
# To enable running this script, you must set PowerShell execution policy to "bypass".
# Run PowerShell (x86) as administrator then execute the following command:
# Set-ExecutionPolicy -ExecutionPolicy Bypass

$file = '../../App.config'
$regex = '(?<=<add key="BuildNumber" value=")[^"]*'
$build = (Get-Date -Format 'yyyyMMddHHmmss');
(Get-Content $file) -replace $regex, $build | Set-Content $file
