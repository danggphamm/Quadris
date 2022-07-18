% Control random seed
rng(0);

load data.txt

% Get the size of the dataset
[numRows, numColumns] = size(data);

% Shuffle the dataset this many times
n = 6;

% Shuffle the dataset n  times
for i = 1:n
    data = data(randperm(size(data, 1)), :);
end

% Size of each fold
stepSize = 19;

% To compute the average accuracy
totalAccGDA = 0;
totalAccLDA = 0;
totalAccQDA = 0;

% To compute the average balanced accuracy
totalBalancedAccGDA = 0;
totalBalancedAccLDA = 0;
totalBalancedAccQDA = 0;

% 10 folds cross validation
for fold = 1:10
    fprintf('\n');
    disp("Fold " + fold); 
    copyData = data;

    % Train and test for each fold
    h = stepSize*(fold-1) + 1;
    
    % Calculate the head and tail index of each fold's test part 
    if fold == 10
        t = numRows;
    else
        t = stepSize*fold;
    end
    
    % Extract the test part
    test = copyData(h:t,:);
    
    % Drop the test part out of the whole dataset to acquire the train part
    copyData([h:t],:) = [];
    train = copyData;
    
    X1 = [];
    X2 = [];

    % Extract variables of each classes from the train dataset of each fold 
    % to form 2 subdatasets
    for i = 1:length(train)
        if (train(i, end) == 1)
            X1( end+1, : ) = train(i, 1:end-1);

        elseif (data(i, end) == 2)
            X2( end+1, : ) = train(i, 1:end-1);
        end
    end

    % Compute means
    mu1 = mean(X1);
    mu2 = mean(X2);

    % Compute Sigma for LDA and GDA
    holder = data;
    holder(:,end) = [];
    sigma = cov(holder);

    % Compute Sigmas for QDA
    sigma1 = cov(X1);
    sigma2 = cov(X2);
    
    % Get the size of the test set
    [rows columns] = size(test);

    %%% GDA %%%
    % To calculate acccuracy
    correctlyClassifiedGDA = 0;
    % True positive, false positive, true negative, false negative
    tp = 0;
    fp = 0;
    tn = 0;
    fn = 0;
    
    %Test session. Loop through each sample of the test set
    for i = 1:rows
        % get x and y of the test sample
        XTest = test(i, 1:end-1);
        YTest = test(i, end);
        
        % Calculate probability
        Px1 = mvnpdf(XTest,mu1,sigma);
        Px2 = mvnpdf(XTest,mu2,sigma);
        
        % Check the prediction
        if Px1 > Px2 
            if YTest == 1
                correctlyClassifiedGDA = correctlyClassifiedGDA + 1;
                tp = tp + 1;
            else
                fp = fp + 1;
            end
        elseif Px2 > Px1 
            if YTest == 2
                correctlyClassifiedGDA = correctlyClassifiedGDA + 1;
                tn = tn + 1;
            else
                fn = fn + 1;
            end
        end
    end
    
    % Print results
    fprintf('\n');
    disp("GDA accuracy: " + correctlyClassifiedGDA*100/rows + "%");
    disp("GDA balanced accuracy: " + (tp/(tp+fp) + tn/(tn+fn))*100/2 + "%");
    
    % For later calculation of average accuracy
    totalAccGDA = totalAccGDA + correctlyClassifiedGDA*100/rows;
    totalBalancedAccGDA = totalBalancedAccGDA + (tp/(tp+fp) + tn/(tn+fn))*100/2;
    
    %%% LDA %%%
    % To calculate acccuracy
    correctlyClassifiedLDA = 0;
    % True positive, false positive, true negative, false negative
    tp = 0;
    fp = 0;
    tn = 0;
    fn = 0;
    
    %Test session. Loop through each sample of the test set
    for i = 1:rows
        % get x and y of the test sample
        XTest = test(i, 1:end-1);
        YTest = test(i, end);
        
        % Calculate probability
        Px1 = XTest*inv(sigma)* mu1'-0.5* mu1 *inv(sigma)* mu1'+log(0.5);
        Px2 = XTest*inv(sigma)* mu2'-0.5* mu2 *inv(sigma)* mu2'+log(0.5);
        
        % Check the prediction
        if Px1 > Px2 
            if YTest == 1
                correctlyClassifiedLDA = correctlyClassifiedLDA + 1;
                tp = tp + 1;
            else
                fp = fp + 1;
            end
        elseif Px2 > Px1 
            if YTest == 2
                correctlyClassifiedLDA = correctlyClassifiedLDA + 1;
                tn = tn + 1;
            else
                fn = fn + 1;
            end
        end
    end
       
    % Print results
    fprintf('\n');
    disp("LDA accuracy: " + correctlyClassifiedLDA*100/rows + "%");
    disp("LDA balanced accuracy: " + (tp/(tp+fp) + tn/(tn+fn))*100/2 + "%");
       
    % For later calculation of average accuracy
    totalAccLDA = totalAccLDA + correctlyClassifiedLDA*100/rows;
    totalBalancedAccLDA = totalBalancedAccLDA + (tp/(tp+fp) + tn/(tn+fn))*100/2;
    
    %%% QDA %%%
    % To calculate acccuracy
    correctlyClassifiedQDA = 0;
    % True positive, false positive, true negative, false negative
    tp = 0;
    fp = 0;
    tn = 0;
    fn = 0;
    
    % Test session. Loop through each sample of the test set
    for i = 1:rows
        % Get x and y of the test sample
        XTest = test(i, 1:end-1);
        YTest = test(i, end);
        
        % Calculate probability
        Px1 = -0.5*log(det(sigma1))- 0.5*(XTest-mu1)*pinv(sigma1)* (XTest-mu1)'+log(0.5);
        Px2 = -0.5*log(det(sigma2))- 0.5*(XTest-mu2)*pinv(sigma2)* (XTest-mu2)'+log(0.5);
        
        % Check the prediction
        if Px1 > Px2 
            if YTest == 1
                correctlyClassifiedQDA = correctlyClassifiedQDA + 1;
                tp = tp + 1;
            else
                fp = fp + 1;
            end
        elseif Px2 > Px1 
            if YTest == 2
                correctlyClassifiedQDA = correctlyClassifiedQDA + 1;
                tn = tn + 1;
            else
                fn = fn + 1;
            end
        end
    end
       
    % Print results
    fprintf('\n');
    disp("QDA accuracy: " + correctlyClassifiedQDA*100/rows + "%");
    disp("QDA balanced accuracy: " + (tp/(tp+fp) + tn/(tn+fn))*100/2 + "%");
    
    % For later calculation of average accuracy
    totalAccQDA = totalAccQDA + correctlyClassifiedQDA*100/rows;
    totalBalancedAccQDA = totalBalancedAccQDA + (tp/(tp+fp) + tn/(tn+fn))*100/2;
end

fprintf('\n');
disp("Average accuracies:");
disp("GDA: " + totalAccGDA/10);
disp("LDA: " + totalAccLDA/10);
disp("QDA: " + totalAccQDA/10);

fprintf('\n');
disp("Average balanced accuracies:");
disp("GDA: " + totalBalancedAccGDA/10);
disp("LDA: " + totalBalancedAccLDA/10);
disp("QDA: " + totalBalancedAccQDA/10);