@echo off
@title PALLAS SERVIDOR AUTOMATICO - CREATE BY Apocryphoon!
cls
color 06
:start

::LOGA NO CONSOLE
echo DESENVOLVIDO POR Apocryphoon#9076

timeout /t 5 >null

::DEFINE ESSE PROCESSO COM O NOME "Server_ESX"
start "Server_ESX" ..\run.cmd +exec server.cfg

::APOS SE PASSAR 10 SEUNGOD DO INICIO DO PROGRAMA ELE IRA EMITIR ESSAS MENSSAGENS
timeout /t 5 >null
echo [%time%] - Iniciando o servidor...

timeout /t 5 >null
echo [%time%] - Carregando arquivos necessarios!

::APOS SE PASSAR 15 SEGUNDOS ELE IRÁ EMITIR ESSAS MENSSAGENS
timeout /t 10 >null
echo [%time%] - Backup concluido
echo [%time%] - Voce pode definir os horarios voce mesmo(a)!

::APOS SE PASSAR 2 SEGUNDOS ELE FINALIZARA OS PROCESSOS.
timeout /t 2 >null

pause