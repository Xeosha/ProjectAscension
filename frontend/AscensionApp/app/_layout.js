
import { Stack } from "expo-router";
import { useFonts, PressStart2P_400Regular } from '@expo-google-fonts/press-start-2p';
import { View, Text } from 'react-native';
import { InventoryProvider } from '../context/InventoryContext';
import { useTelegramScript, useTelegramUserUnsafe } from "../hooks/useTelegramScript";

export default function RootLayout() {
  const [fontsLoaded] = useFonts({
    PressStart2P_400Regular,
  });

  //seTelegramScript();

  //const user = useTelegramUserUnsafe();

  if (!fontsLoaded) {
    return <View><Text>Hello</Text></View>;
  }

  //if (!user) {
    //<Redirect href="/(auth)/auth" />;
  //}

  return (
    <InventoryProvider> 
      {
        <Stack 
        screenOptions={{ headerShown: false }}
      />  
      }
    </InventoryProvider>    
  );
} 