#Autohaus Dev Demo Site
A demo site built by developers for developers. Learn about the latest features in Sitecore 7. Provided AS IS, no guarantees or support. Please use this website as a learning tool only.

##What to expect from this demo site
* Learn how to leverage new Content Search API (Linq) from examples.
* Learn how to build faceting experience.
* Learn how to extend the new features in Sitecore 7.
* Examples of how you can build a basic oData compatible service.

##What you shouldn't expect from this demo site
* Production quality code. Please avoid using the code from the samples on your production systems without thorough testing. This includes C#, JavaScript and CSS.
* Polished front-end experience.

Please, remember - this is a demo site at the end of the day :-)

##Requirements

1. Exact build of 7.0 rev. 130424.
2. Sitecore MVC disabled. To do so, rename the extension of the Sitecore.Mvc* config files under App_Config/Include.
3. MVC 4 installed on the server. You can grab it from Microsoft Web Platform Installer.
   This is needed for ASP.NET oData Controller (Microsoft.Web.Infrastructure.dll component).
	
##How to install the site

Simply get the latest .update file from /download and install it with /sitecore/admin/UpdateInstallationWizard.aspx.

The package will deploy tons of items in post-install, so it could take a while (5-10 minutes to finish).
Afterwards, it will kick off index rebuild of the master indexes.
No manual steps are required after the install.

**Important:**
The site operates in Live Mode, meaning it's using the *master* database and *sitecore_master_index*

##How to build locally

After you get the sources:

1. Drop the following DLLs from your Sitecore 7.0 rev. 130424 distributive to /sc.lib.

* HtmlAgilityPack.dll
* Lucene.Net.Contrib.Analyzers.dll
* Lucene.Net.dll
* Sitecore.Buckets.Client.dll
* Sitecore.Buckets.dll
* Sitecore.Client.dll
* Sitecore.ContentSearch.dll
* Sitecore.ContentSearch.Linq.dll
* Sitecore.ContentSearch.Linq.Lucene.dll
* Sitecore.ContentSearch.LuceneProvider.dll
* Sitecore.Kernel.dll
* Sitecore.Logging.dll
* Sitecore.Update.dll
* Sitecore.Zip.dll

2. Open the solution file.

   If you use TDS, open Autohaus.sln. If you don't, use Autohaus.NoTDS.sln.
   
3. If you use TDS: tweak the TDS project settings for Debug configuration like the webroot path, etc.

4. Hit Rebuild All.
   If you do not use TDS, you will have to copy the project output to the install directory yourself.

5. Once you build successfully, make sure your local sandbox is operational.
6. Afterwards, if you are using TDS, do Deploy (it may be disabled in the Debug configuration). If you do not use TDS, then you will have to copy the .item files from the TDS project folder to your local /serialization folder and perform Update Database operation.

**Important**:
Note that the TDS project does not contain the car models, just the baseline items. In order to install the items, you will need to install the .update package from the /download folder first.






