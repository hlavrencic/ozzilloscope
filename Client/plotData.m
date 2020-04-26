function plotData (filename)

if nargin == 0
    filename = uigetfile('*.*');
end

delimiter = ',';

formatSpec = '%f%f%[^\n\r]';
fileID = fopen(filename,'r');
dataArray = textscan(fileID, formatSpec, 'Delimiter', delimiter,  'ReturnOnError', false);

fclose(fileID);

vals = dataArray{:, 1};
times = dataArray{:, 2};

figure;
plot(times / 1000, vals * 5 / 1023);
xlabel('Time / ms');
ylabel('Voltage');

end