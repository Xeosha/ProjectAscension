import { Stack } from "expo-router";
import { useFonts, PressStart2P_400Regular } from '@expo-google-fonts/press-start-2p';
import { View, Text } from 'react-native';

export default function RootLayout() {
  const [fontsLoaded] = useFonts({
    PressStart2P_400Regular,
  });

  if (!fontsLoaded) {
    return <View><Text>Hello</Text></View>;
  }

  return (
      <Stack 
        screenOptions={{ headerShown: false }}
      />  
  );
} 