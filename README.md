EoD_New
=======
Zoonou End Of Day Report Tool

Tool Details	
Tool Name:	End of Day Report Tool (EoD)
Creator: 	BV
Beta Testers:	AF/MG
Tool Goal:	To enable testers the ability to create end of day reports quickly and in a consistent manner. This is achieved by filling out the fields and answering the questions within the tool to create correct reports, in the correct style, layout and design every time with little or no editing required.


Tool Requirements	
Installation prerequisites:	Microsoft Windows:
The tool was designed and developed for Microsoft Windows OS systems.

Supported version:
Windows 7

GTK#:
Graphical user interface toolkit for Mono and .NET. The project binds the GTK+ toolkit and assorted GNOME libraries, enabling fully native graphical Gnome application development using the Mono and .NET development frameworks.

Version:
2.12.21

Download:
download.xamarin.com/GTKforWindows/Windows/gtk-sharp-2.12.21.msi

Details of the package can be found here:
http://www.mono-project.com/GtkSharp
http://npackd.appspot.com/p/gtksharp/2.12.21
http://en.wikipedia.org/wiki/Gtk_Sharp

Microsoft .NET Framework:
The Microsoft .NET Framework 4 web installer package downloads and installs the .NET Framework components required to run on the target machine architecture and OS. An Internet connection is required during the installation. .NET Framework 4.5 is required to run and develop applications to target the .NET Framework.

Version:
 4.5+

Download:
http://www.microsoft.com/en-gb/download/details.aspx?id=40779
Details: 
http://en.wikipedia.org/wiki/.NET_Framework

Microsoft Word:
The document produced by tool requires Microsoft Word installed on the user’s machine for creation and editorial purposes. The tool exports into the Word file format of ‘.docx’. By default the Word file is then opened by the tool as part of the last stage in the tool’s process. 

Supported versions:
2010
2013

Development note:  
Other versions of Word may function but will not be 100% compatible with the tool and the user may experience issues.  

Installation Issues:	Users may need to remove/uninstall any existing versions of the software detailed above before completing the installation process.

Installation/Use Guide:	1.	Uninstall/delete any previous EoD/GTK/.Net versions
2.	Ensure either 2010 or 2013 Microsoft Word is installed
3.	Download and install .NET Framework  http://www.microsoft.com/en-gb/download/details.aspx?id=40779
4.	Download and install GTK# 2.12.21 (download.xamarin.com/GTKforWindows/Windows/gtk-sharp-2.12.21.msi)
5.	Launch EoD.exe (Located:...
6.	Use application

Tool Notes	
Development:	This version of the tool was supposed to include a list of devices that was used in testing, however various flaws were analysed and it was decided that a database was the best cause of action. Thus this has not been implemented into this build. Please result to the standard way of implementing the device list into the report. (I.e. copying and pasting).  

Other tool designs are currently undergoing development to resolve the above issue. 

Development tools:	An integrated development environment (IDE) Xamarin Studio was used to create the EoD tool. 

Wiki:
http://en.wikipedia.org/wiki/Xamarin
Home:
http://xamarin.com/studio?_bt=44014804148&_bk=xamarin%20studio&_bm=e&gclid=CNPE_vu9-70CFbMftAodGG0ASQ

Xamarin Studio (Details taken from: 25/04/2014)
Version 4.2.3 (build 60)
Installation UUID: 4ebffa74-39fa-437e-80dc-702b21a3b99e
Runtime:
	Microsoft .NET 4.0.30319.1022
	GTK+ 2.24.22 theme: MS-Windows
	GTK# (2.12.0.0)

Revision Control	GitHub
GitHub is a web-based hosting service for software development projects that use the Git revision control system. GitHub offers both paid plans for private repositories, and free accounts for open source projects. 
Wiki:
http://en.wikipedia.org/wiki/GitHub
Home:
https://github.com/
