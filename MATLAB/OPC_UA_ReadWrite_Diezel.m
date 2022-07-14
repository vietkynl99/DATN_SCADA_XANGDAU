function output=OPC_UA_ReadWrite_Diezel(input)
%% initialize variables
persistent init_Server init_Nodes uaClient;
persistent in1 in2 in3 in4 in5 in6;
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
    
    in1 = opcuanode(3,'"Diezel"."BatchReady"',uaClient);
    in2 = opcuanode(3,'"Diezel"."BatchRunning"',uaClient);
    in3 = opcuanode(3,'"Diezel"."BatchControlVal"',uaClient);
    in4 = opcuanode(3,'"Diezel"."Vout"',uaClient);
    in5 = opcuanode(3,'"Diezel"."FlowOutPER"',uaClient);
    in6 = opcuanode(3,'"Diezel"."LevelPER"',uaClient);
    out1 = opcuanode(3,'"Diezel"."StartOut"',uaClient);
    out2 = opcuanode(3,'"Diezel"."EstopOut"',uaClient);
    out3 = opcuanode(3,'"Diezel"."Enable"',uaClient);
    out4 = opcuanode(3,'"Diezel"."SetpointOut"',uaClient);
    

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
    %read data
    output(1)=double(readValue(uaClient, out1));
    output(2)=double(readValue(uaClient, out2));
    output(3)=double(readValue(uaClient, out3));
    output(4)=double(readValue(uaClient, out4));
end
end