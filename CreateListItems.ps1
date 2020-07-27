Add-Type -Path "C:\Program Files\Common Files\microsoft shared\Web Server Extensions\16\ISAPI\Microsoft.SharePoint.Client.dll"
Add-Type -Path "C:\Program Files\Common Files\microsoft shared\Web Server Extensions\16\ISAPI\Microsoft.SharePoint.Client.Runtime.dll"  
  
$siteURL = "https://o365boss.sharepoint.com/sites/MO"  
$userId = "user@o365boss.onmicrosoft.com"  
$pwd = Read-Host -Prompt "Enter password" -AsSecureString  
$creds = New-Object Microsoft.SharePoint.Client.SharePointOnlineCredentials($userId, $pwd)  
$ctx = New-Object Microsoft.SharePoint.Client.ClientContext($siteURL)  
$ctx.credentials = $creds  
try{  
    $lists = $ctx.web.Lists  
    $list = $lists.GetByTitle("Guawa") 
    for($i = 0;$i -le 1000 ; $i++)
    {
        $listItemInfo = New-Object Microsoft.SharePoint.Client.ListItemCreationInformation  
        $listItem = $list.AddItem($listItemInfo)  
        $listItem["Title"] = "Begusarai"+$i
        $listItem["PINcode"] = $i  
        $listItem.Update()      
        $ctx.load($list)      
        $ctx.executeQuery()  
        Write-Host -ForegroundColor Green "Item Added with ID - " $listItem.Id 
    }     
}  
catch{  
    write-host "$($_.Exception.Message)" -foregroundcolor red  
} 