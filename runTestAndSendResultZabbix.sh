#!/bin/bash -x

#load env
. runTest.conf.sh

function SEND_ZABBIX(){
    zabbix_sender -z $ZABBIX_SERVER -s $MONIT_HOSTNAME -k $MONIT_KEY -o "$1"
}

DISPLAY=:1 xvfb-run dotnet run --no-build | grep -v 'Connection refused Connection refused' > test.log
if grep -e "0 failed" test.log; then
    SEND_ZABBIX 0
else
    SEND_ZABBIX 1
    cp -pr test.log ./log/error-`date +%Y-%m-%dT%H%M%S`.log
fi

