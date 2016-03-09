# CodingTest

###To run the project

Go to the command line on your machine and type:

`git clone git@github.com:monkieboy/CodingTest.git`

To build the project continue on the command line and go to the root of the project just cloned then type:

`mono .paket/paket.bootstrapper.exe`

This will download the latest version of paket. When the download has completed you can type:

`mono .paket/paket.exe install`

**NOTE: If you are on Windows**
 * You can omit `mono`
 * The slashes **might need to be back slashes** also.

The project can be loaded now, all you need is a test runner, NCrunch (http://www.ncrunch.net/) has a 30 trial if you don't have one built-in, but you can use whatever you prefer.

**The project is simple, just an implementation and test project each with a single file in each; Harness.fs and NumberGenTests.fs, respectively.**

<pre>
CodingTest.sln
|_CodingTest.fsproj
|   |_Harness.fs
|
|_CodingTest.Tests.fsproj
    |_NumberGenTests.fs
</pre>
