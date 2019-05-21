import { Address } from "./address.model";

export interface Person {
  firstName: string;
  lastName: string;
  age: number;
  interests: string;
  pictureUrl: string;
  address: Address;
}
