export interface UserRegistrationDto {
    userName: string;
    password: string;
    confirmPassword: string;
    user: {
        dateOfBirth: string,
        firstName: string,
        lastName: string,
        middleName?: string,
        photo: {
            id: number
            url?: string,
        }    
    };
}