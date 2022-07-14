function output=OPC_UA_ReadWrite_E5(input)
%% initialize variables
persistent init_Server init_Nodes uaClient;
persistent in1 in2 in3 in4 in5 in6 in7 in8 in9;
persistent out1 out2 out3 out4;
if isempty(init_Server)
    init_Server=0;
    init_Nodes=0;
end

%% OPC UA server (PLC) address and connecting client to the server
if init_Server == 0
    
    HostName='192.168.0.3';
    PortAddress=4840;
    
    uaClient = opcua(HostName,PortAddress);
    %check version
    ver=version('-release'); ver(end)=[];
    ver=str2double(ver);
    if ver>2019
        setSecurityModel(uaClient,'None');
    end
    connect(uaClient);
    init_Server = 1;
end

%% define variable nodes in the server
if uaClient.isConnected == 1 && init_Nodes == 0
    init_Nodes  = 1;  
    
    in1 = opcuanode(3,'"E5"."BatchReady"',uaClient);
    in2 = opcuanode(3,'"E5"."BatchRunning"',uaClient);
    in3 = opcuanode(3,'"E5"."Vout"',uaClient);
    in4 = opcuanode(3,'"E5"."BatchValRON92"',uaClient);
    in5 = opcuanode(3,'"E5"."BatchValE100"',uaClient);
    in6 = opcuanode(3,'"RON92"."LevelPER"',uaClient);
    in7 = opcuanode(3,'"E100"."LevelPER"',uaClient);
    in8 = opcuanode(3,'"E5"."FlowOutRON92PER"',uaClient);
    in9 = opcuanode(3,'"E5"."FlowOutE100PER"',uaClient);
    out1 = opcuanode(3,'"E5"."StartOut"',uaClient);
    out2 = opcuanode(3,'"E5"."EstopOut"',uaClient);
    out3 = opcuanode(3,'"E5"."Enable"',uaClient);
    out4 = opcuanode(3,'"E5"."SetpointOut"',uaClient);
    

end

%% read and write data
if uaClient.isConnected == 1 && init_Nodes == 1
    %write data
    writeValue(uaClient, in1, input(1));
    writeValue(uaClient, in2, input(2));
    writeValue(uaClient, in3, input(3));
    writeValue(uaClient, in4, input(4));
    writeValue(uaClient, in5, input(5));
    writeValue(uaClient, in6, input(6));
    writeValue(uaClient, in7, input(7));
    writeValue(uaClient, in8, input(8));
    writeValue(uaClient, in9, input(9));
    %read data
    output(1)=double(readValue(uaClient, out1));
    output(2)=double(readValue(uaClient, out2));
    output(3)=double(readValue(uaClient, out3));
    output(4)=double(readValue(uaClient, out4));
end
end