<h1>Autohaus</h1>
<p>A demo site built by developers for developers. Learn about the latest features in Sitecore 7.</p>
<p>Provided AS IS, no guarantees or support.</p>
<p>Please use this website as a learning tool only.</p>
<h2>What to expect from this demo site</h2>
<ul>
<li>Learn how to leverage new Content Search API (Linq) from examples.</li>
<li>Learn how to build faceting experience.</li>
<li>Learn how to extend the new features in Sitecore 7.</li>
<li>Examples of how you can build a basic oData compatible service.</li>
</ul>
<h2>What you shouldn't expect from this demo site</h2>
<ul>
<li>Production quality code. Please avoid using the code from the samples on your production systems without thorough testing. This includes C#, JavaScript and CSS.</li>
<li>Polished front-end experience.</li>
</ul>
<p>
<b>Please, remember - this is a demo site at the end of the day :-)</b>
</p>
<h2>Requirements</h2>

1.	Exact build of 7.0 rev. 130424.

2.	Sitecore MVC disabled.
	To do so, rename the extension of the Sitecore.Mvc* config files under App_Config/Include.
	
<h2>How to install the site</h2>

Simply get the latest .update file from /download and install it with /sitecore/admin/UpdateInstallationWizard.aspx.

The package will deploy tons of items in post-install, so it could take a while (5-10 minutes to finish).
Afterwards, it will kick off index rebuild of the master indexes.
No manual steps are required after the install.

<p><b>Important: </b>The site operates in Live Mode, meaning it's using the <i>master</i> database and <i>sitecore_master_index</i>.</p>

<h2>How to build locally</h2>

After you get the sources:

1. Drop the following DLLs from your Sitecore 7.0 rev. 130424 distributive to /sc.lib.
<ul>
<li>HtmlAgilityPack.dll
<li>Lucene.Net.Contrib.Analyzers.dll</li>
<li>Lucene.Net.dll</li>
<li>Sitecore.Buckets.Client.dll</li>
<li>Sitecore.Buckets.dll</li>
<li>Sitecore.Client.dll</li>
<li>Sitecore.ContentSearch.dll</li>
<li>Sitecore.ContentSearch.Linq.dll</li>
<li>Sitecore.ContentSearch.Linq.Lucene.dll</li>
<li>Sitecore.ContentSearch.LuceneProvider.dll</li>
<li>Sitecore.Kernel.dll</li>
<li>Sitecore.Logging.dll</li>
<li>Sitecore.Update.dll</li>
<li>Sitecore.Zip.dll</li>
</ul>
2. Open the solution file.

   If you use TDS, open Autohaus.sln. If you don't, use Autohaus.NoTDS.sln.
   
3. If you use TDS: tweak the TDS project settings for Debug configuration like the webroot path, etc.

4. Hit Rebuild All.
   If you do not use TDS, you will have to copy the project output to the install directory yourself.

5. Once you build successfully, make sure your local sandbox is operational.
6. Afterwards, if you are using TDS, do Deploy (it may be disabled in the Debug configuration). If you do not use TDS, then you will have to copy the .item files from the TDS project folder to your local /serialization folder and perform Update Database operation.

<p><b>Important: </b>Note that the the TDS project does not contain the car models, just the baseline items. In order to install the items, you will need to install the .update package from the /download folder first.</p>






