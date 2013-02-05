//
//  RPSModel.m
//  Rock Paper Scissors
//
//  Created by Corey Featherly on 1/8/13.
//  Copyright (c) 2013 myself. All rights reserved.
//

#import "RPSModel.h"

static int selectionRock = 0;
static int selectionPaper = 1;
static int selectionScissors = 2;

@implementation RPSModel

@synthesize lifetimeWins = _lifetimeWins;
@synthesize lifetimeLoses = _lifetimeLoses;
@synthesize lifetimeTies = _lifetimeTies;
@synthesize history = _history;
@synthesize enemySelection = _enemySelection;


-(NSInteger)setEnemySelection{
    _enemySelection = rand() % (2-0+1)+0;
    return _enemySelection;
}

-(NSString*)roundResult1P:(NSInteger)playerSelection
{
    // NSInteger randNumber = rand() % (max-min+1)+min
    [self setEnemySelection];
    NSLog(@"Enemy Selection: %d", self.enemySelection);

    NSString *strSelection;
    if(playerSelection==0)
        strSelection = @"rock";
    else if(playerSelection==1)
        strSelection = @"paper";
    else if (playerSelection==2)
        strSelection = @"scissors";
    if(playerSelection == self.enemySelection){
        self.lifetimeTies = self.lifetimeTies + 1;
        return @"tie";

    } else if (playerSelection == selectionRock){
        if(self.enemySelection==selectionScissors){
            self.lifetimeWins = self.lifetimeWins + 1;
            return @"win";
        }
        else{
            self.lifetimeLoses=self.lifetimeLoses+1;
            return @"loss";
        }
    } else if (playerSelection == selectionPaper){
        if(self.enemySelection==selectionRock){
            self.lifetimeWins = self.lifetimeWins + 1;
            return @"win";
        }
        else{
            self.lifetimeLoses=self.lifetimeLoses+1;            
            return @"loss";
        }
    } else if (playerSelection == selectionScissors){
        if(self.enemySelection==selectionPaper){
            self.lifetimeWins = self.lifetimeWins + 1;            
            return @"win";
        }
        else{
            self.lifetimeLoses=self.lifetimeLoses+1;            
            return @"loss";            
        }

    } else {
        return @"invalid";
    }
}

@end
