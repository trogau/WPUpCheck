# WPUpCheck

http://trog.qgl.org/wpupcheck/

WPUpCheck is a simple tool for Windows that periodically polls a WordPress installation to check for updates.

It was developed to run permanently in the background and notify users through a simple systray balloon when updates (to WordPress core, plugins, or themes) are detected. 

It uses XML-RPC to perform the check and requires a simple plugin be installed on WordPress to handle the checking. 

## Build Requirements

* Visual Studio 2013
* XML-RPC.NET - http://xml-rpc.net/download.html

## Running Requirements

* XML-RPC Update Check plugin for WordPress: https://wordpress.org/plugins/xml-rpc-update-check/

## TODO

* Finish support to allow checking multiple WordPress installs
* Fix location of automagically created application directories/registry stuff to make it portable
* Fix minimise behaviour

## Contact

Twitter: @trawg
