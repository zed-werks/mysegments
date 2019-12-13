export default interface AthleteProfile {

    // unique user id
     id: number;

     // username, usually firstname_lastname
     username: string;

     // User's first name
     firstname: string;

     // User's surname
     lastname: string;

     //  athlete home city/town
     city: string;

     // athlete's state/province
     state: string;

     // athlete's country
     country: string;

     // url to user's profile image, if set.
     profile: string; 

     // units of measure - feet or meters (metres?)
     measurementPreference: string;  // feet or metres
}
