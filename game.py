import random

def game():
    number = random.randint(1, 100)
    print("\n--- Welcome to the Guessing Game! ---")
    level = input("Choose difficulty 'easy' or 'hard': ").lower()
    attempts = 10 if level == 'easy' else 5
    score = 100

    while attempts > 0:
        print(f"\nYou have {attempts} attempts left.")
        try:
            guess = int(input("Make a guess: "))
        except ValueError:
            print("Please enter a valid number!")
            continue
            
        if guess == number:
            print(f"Correct! The number was {number}. Your score: {score}")
            return
        elif guess > number:
            print("Too high!")
        else:
            print("Too low!")
        
        attempts -= 1
        score -= 10

    print(f"\nGame Over! The number was {number}.")

while True:
    game()                  
    again = input("\nDo you want to play again? (y/n): ").lower()
    if again != 'y':        
        print("Goodbye!")  
        break