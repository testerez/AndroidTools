AndroidTools
============

`AndroidTools` is a command line tools for Android developers. It will some day provide many commands but there is only one available for the time being.
    
copyres
-------
Find and copy all versions of a resourse from one res folder to another.

usage:
    
    AndroidTools copyres <options>

  - `-s, --source=VALUE`         Source res path
  - `-d, --destination=VALUE`    Destination res path
  - `-r, --res=VALUE`            res name (with extension)
  - `-f, --force`                Overwrite destination file if exists
