@echo off

gacutil -u DevExpress.Data.v10.1
mkdir %windir%\assembly\GAC_MSIL\DevExpress.Data.v10.1\10.1.4.0__b88d1754d700e49a
copy DevExpress.Data.v10.1.dll %windir%\assembly\GAC_MSIL\DevExpress.Data.v10.1\10.1.4.0__b88d1754d700e49a

gacutil -u DevExpress.Utils.v10.1
mkdir %windir%\assembly\GAC_MSIL\DevExpress.Utils.v10.1\10.1.4.0__b88d1754d700e49a
copy DevExpress.Utils.v10.1.dll %windir%\assembly\GAC_MSIL\DevExpress.Utils.v10.1\10.1.4.0__b88d1754d700e49a


echo 'OK'
pause