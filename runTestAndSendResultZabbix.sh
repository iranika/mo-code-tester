#!/bin/bash -x

function SEND_ZABBIX(){
    ZABBIX_SERVER="*********"
    MONIT_HOSTNAME="WebTest"
    MONIT_KEY="webtest.result"
    zabbix_sender -z $ZABBIX_SERVER -s $MONIT_HOSTNAME -k $MONIT_KEY -o "$1"
}

DISPLAY=:1 xvfb-run dotnet run --no-build | grep -v 'Connection refused Connection refused' > test.log
grep -e "0 failed" test.log && SEND_ZABBIX "webtest was passed" || SEND_ZABBIX "webtest was failed"

