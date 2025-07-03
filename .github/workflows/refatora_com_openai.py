import openai
import os

openai.api_key = os.getenv("OPENAI_API_KEY")

def refatorar_codigo(codigo_trecho, prompt_extra=""):
    prompt = (
        "Refatore o seguinte código para usar a biblioteca 'validate-docbr' para validação de CNPJ:\n"
        + codigo_trecho
        + "\nRefatore apenas o necessário."
    )
    resposta = openai.ChatCompletion.create(
        model="gpt-4",
        messages=[
            {"role": "system", "content": "Você é um especialista em Python e CNPJ."},
            {"role": "user", "content": prompt}
        ],
        max_tokens=800,
        temperature=0.2
    )
    return resposta['choices'][0]['message']['content'].strip()

def processar_arquivos():
    for nome_arquivo in os.listdir("."):
        if nome_arquivo.endswith(".py") and nome_arquivo != "refatora_com_openai.py":
            with open(nome_arquivo, "r", encoding="utf-8") as f:
                conteudo = f.read()
            if "cnpj" in conteudo.lower():
                novo_codigo = refatorar_codigo(conteudo)
                with open(nome_arquivo, "w", encoding="utf-8") as f:
                    f.write(novo_codigo)

if __name__ == "__main__":
    processar_arquivos()