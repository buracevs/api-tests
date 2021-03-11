#!/bin/sh
echo "hello"

dotnet test "./src/UnitTests/MainUnitTests/MainUnitTests.csproj"

rc=$?
if [ $rc != 0 ]
then 
echo "[ERROR] test failed"
exit 1
else 
echo "[OK] test passed"
#exit 0

fi

#validate email
userman=$(git config user.email)
if [ "$userman" != "buracevs@gmail.com" ]
then
	cat <<\EOF
Error: user.email not set to "buracevs@gmail.com"
EOF
	exit 1
	
fi

#--no-verify to exclude hooks