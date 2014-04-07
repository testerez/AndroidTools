AndroidTools
============

Command line tools for Android developers. For now there is only one available command.
    
Command 'copyres'
----------------
Find and copy all versions of a resourse from one res folder to another.

Expected usage:
    AndroidTools.exe copyres <options>
    
<options> available:
  -f, --force                Overwrite destination file if exists
  -s, --source=VALUE         Source res path
  -d, --destination=VALUE    Destination res path
  -r, --res=VALUE            res name (with extension)
