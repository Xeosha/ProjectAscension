import { Redirect } from 'expo-router';
import Head from 'expo-router/head';

export default function Index() {
  return (
    <>
      <Head>
          <script src="https://telegram.org/js/telegram-web-app.js" />
      </Head>
      <Redirect href="/(auth)/auth" />;
    </>
  );
  
  
 
}