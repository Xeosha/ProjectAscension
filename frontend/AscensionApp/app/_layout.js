import { Stack } from "expo-router";
import { StatusBar } from 'expo-status-bar';
import { useFonts, PressStart2P_400Regular } from '@expo-google-fonts/press-start-2p';
import AppLoading from "expo-app-loading";

export default function RootLayout() {
  const [fontsLoaded] = useFonts({
    PressStart2P_400Regular,
  });

  if (!fontsLoaded) {
    return <AppLoading />;
  }

  return (
    <>
      <StatusBar style="dark" backgroundColor="#000000" />
      <Stack 
        screenOptions={{ headerShown: false }}
      />  
    </>
    
  );
} 