clc
clear all

%% kiem tra thong tin Server OPC UA cua BR
% opcuaserverinfo localhost

%%
disp('Connectting to OPC UA Server...')
OPC_UA_Port=4840;
uaClient = opcua('192.168.0.3',OPC_UA_Port);
connect(uaClient)

status=uaClient.Status

% varNodes=browseNamespace(uaClient)

% value=readValue(uaClient,varNodes)
% writeValue(uaClient, varNodes, 1)
% value=readValue(uaClient,varNodes)


input1_Node=opcuanode(3,'"Diezel"."SetpointOut"',uaClient)

% input1_Node=findNodeByName(uaClient.Namespace,'OPC_UA_DB.input1','-once')
% input2_Node=findNodeByName(uaClient.Namespace,'input2','-once')
% output1_Node=findNodeByName(uaClient.Namespace,'output1','-once');
% output2_Node=findNodeByName(uaClient.Namespace,'output2','-once');

val1=readValue(uaClient,input1_Node)
% val2=readValue(uaClient,input2_Node)
% writeValue(uaClient, output1_Node, 1)
% writeValue(uaClient, output2_Node, 1)


disconnect(uaClient)

%% tai lieu tham khao
% https://www.mathworks.com/help/opc/ug/read-and-write-current-opc-ua-server-data.html
% https://www.mathworks.com/help/opc/ug/read-historical-opc-ua-server-data.html
% https://www.mathworks.com/help/opc/index.html?s_tid=CRUX_lftnav
% https://www.mathworks.com/help/opc/unified-architecture.html
